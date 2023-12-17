using TMPro;
using UnityEngine;

public class BuyingManager : MonoBehaviour
{
    private int itensCost;
    private int totalItensPrice;
    [SerializeField] private CharacterSkeleton charSkeleton;
    [SerializeField] private TextMeshProUGUI infoPurchasingText;
    [SerializeField] private TextMeshProUGUI[] pricesText;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private CustomizableManager[] customizableObjects;
    private bool iVeBought = false;

    public void AbleToPurchase()
    {
        totalItensPrice = 0;
        for(int i = 0; i < 3; i++)
        {
            totalItensPrice += charSkeleton.characterSkeletonMember[i].bodyPart.itemPriceCost;
        }   

        // purchinsing intention price
        itensCost = totalItensPrice;

        if(PlayerWallet.instance.coinsAmount >= itensCost)
        {
            Debug.Log("Apply Clotes Changes");
            customizableObjects[0].UpdateBodyParts();
            PlayerWallet.instance.coinsAmount -= itensCost;
            itensCost = 0;
            iVeBought = true;
        }
        else
        {
            infoPurchasingText.text = "Hmm... Seams like your wallet is empty :'(";
            iVeBought = false;
            Invoke("ClosingIfDontHaveMoney", 2f);
        }

    }
    public void ClosingBuyingSection()
    {
        pricesText[0].text = "";
        pricesText[1].text = "";
        infoPurchasingText.text = "";
        DialogManager.Instance.ClosingDialog(DialogManager.Instance.DialogInstance);
        shopPanel.SetActive(false);
        //itens cost back to 0 value after closing the store
        itensCost = 0;
        iVeBought = false;
    }
    private void ClosingIfDontHaveMoney()
    {
        pricesText[0].text = "";
        pricesText[1].text = "";
        infoPurchasingText.text = "";
        DialogManager.Instance.ClosingDialog(DialogManager.Instance.DialogInstance);
        shopPanel.SetActive(false);
        itensCost = 0;
        iVeBought = false;
    }

    private void OnEnable() {
        customizableObjects[1].UpdateBodyParts();
    }
}

