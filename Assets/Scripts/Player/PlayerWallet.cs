using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int coinsAmount;
    [SerializeField] private TextMeshProUGUI[] coinsText;

    // Singleton
    public static PlayerWallet instance;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        coinsText[0].text = coinsAmount.ToString();
        coinsText[1].text = coinsAmount.ToString();
    }

    public void SellingItens( int amount)
    {
        coinsAmount+= amount;
    }
}
