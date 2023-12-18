using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSellStore : MonoBehaviour
{
    [SerializeField] private GameObject sellStorePanel;
    public void ClosingStore()
    {
        DialogManager.Instance.ClosingDialog(DialogManager.Instance.DialogInstance);
        sellStorePanel.SetActive(false);
    }
}
