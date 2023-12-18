using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Usable Item", menuName = "Usable")]
public class UsableItem : ScriptableObject
{
    [SerializeField] private string usableItemtName;
    public Sprite usableItemImage;
    public int itemPriceCost;
    public int usableItemIndex;
}
