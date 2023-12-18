using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private UsableItem item;

    public int ReturnItemIndex()
    {
        return item.usableItemIndex;
    }
}
