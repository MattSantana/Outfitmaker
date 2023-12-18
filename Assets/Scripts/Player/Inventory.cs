using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject slots;
    [SerializeField] private ItemUsableSelection[] itemUsableSelection;
    public Image[] slotImages;
    public Sprite[] collectedItensSprites;
    public static Inventory instance;
    public int[] collectedItensPrice;
    private int slotIndex = -1;
    private int currentItemIndex;

    public delegate void OnSellerActive();
    public static OnSellerActive onSellerActive;

    private void Awake() {
        instance = this;
        onSellerActive+= UpdateSlotVisibility;
    }
    private void Start() 
    {
        slotImages = slots.GetComponentsInChildren<Image>();
    }

    public void UpdateSlotVisibility()
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (slotImages[i].sprite == null)
            {
                slotImages[i].gameObject.SetActive(false);
            }
            else
            {
                slotImages[i].gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Collectible")
        {
            slotIndex++;
            Debug.Log(slotIndex);
            if( slotIndex > slotImages.Length)
            {
                Debug.Log("Inventory Full");
                return;
            }
            else
            {
                currentItemIndex = other.GetComponent<Collectible>().ReturnItemIndex();
                Debug.Log(currentItemIndex);

                if (slotIndex < collectedItensSprites.Length)
                {
                    collectedItensSprites[slotIndex] = itemUsableSelection[currentItemIndex].usablesOptions[0].usableItemImage;
                    slotImages[slotIndex].sprite = collectedItensSprites[slotIndex];
                }
                if (slotIndex < collectedItensPrice.Length)
                {
                    collectedItensPrice[slotIndex] = itemUsableSelection[currentItemIndex].usablesOptions[0].itemPriceCost;
                }
                Destroy(other.gameObject);
            }
        }
    }

    private void OnDisable() {
        onSellerActive-= UpdateSlotVisibility;
    }
}
[System.Serializable]
public class ItemUsableSelection
{
    public string usableItemName;
    public UsableItem[] usablesOptions;
    public TextMeshProUGUI itemPriceTextComponent;
    [HideInInspector] public int usableCurrentIndex;
}
