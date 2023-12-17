using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int coinsAmount;
    [SerializeField] private TextMeshProUGUI coinsText;

    // Singleton
    public static PlayerWallet instance;

    private void Awake() {
        instance = this;
    }

    private void Update() {
        coinsText.text = coinsAmount.ToString();
    }

}
