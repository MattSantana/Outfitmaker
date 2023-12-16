using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    [SerializeField] private Dialog dialog;

    private void Awake() {
        DialogManager.onPlayerInteract+=Interact;
    }
    private void Interact()
    {
        DialogManager.Instance.ShowDialog(dialog);
    }

    private void OnDisable() {
        DialogManager.onPlayerInteract-=Interact;
    }
}
