using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject slots;
    [SerializeField] private ItemUsableSelection[] itemUsableSelection;
    public Image[] slotImages;
    public Sprite[] collectedItensSprites;
    public int[] collectedItensPrice;
    private int slotIndex = -1;
    private int currentItemIndex;
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
}
[System.Serializable]
public class ItemUsableSelection
{
    public string usableItemName;
    public UsableItem[] usablesOptions;
    public TextMeshProUGUI itemPriceTextComponent;
    [HideInInspector] public int usableCurrentIndex;
}
