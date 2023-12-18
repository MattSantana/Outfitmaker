using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] private Dialog dialog;

    private void Awake() {
        if(gameObject.tag == "SellerOwner")
        {
            DialogManager.onSellerInteract+=Interact;
        }
        else
        {
            DialogManager.onBuyerInteract+=Interact;
        }        
    }
    private void Interact()
    {
        StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
    }

    private void OnDisable() {
        if(gameObject.tag == "SellerOwner")
        {
            DialogManager.onSellerInteract-=Interact;
        }
        else
        {
            DialogManager.onBuyerInteract-=Interact;
        } 
    }
}
