using UnityEngine.UI;
using UnityEngine;

public class SellButtonAction : MonoBehaviour
{
    [SerializeField] private Image slotImage;
    [SerializeField] private GameObject slots;
    private GameObject[] slotsIndex;

    private void Start() {
        slotsIndex = new GameObject[slots.transform.childCount];
        for (int i = 0; i < slotsIndex.Length; i++)
        {
            slotsIndex[i] = slots.transform.GetChild(i).gameObject;
        }
    }
    public void SellingTheItem()
    {
        int index = System.Array.IndexOf(slotsIndex, slotImage.gameObject);

        slotImage.GetComponent<Button>().interactable = true;
        slotImage.sprite = null;
        slotImage.gameObject.SetActive(false);
        int amount = Inventory.instance.collectedItensPrice[index];
        PlayerWallet.instance.SellingItens(amount);
        
    }
}
