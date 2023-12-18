using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingInventory : MonoBehaviour
{
    private void OnEnable() {
        Inventory.onSellerActive?.Invoke();
    }
}
