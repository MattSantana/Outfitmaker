using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    [SerializeField] private Button slotsButtons;
    [SerializeField] private GameObject sellButton;
    void Start()
    {
        slotsButtons.onClick.AddListener(OnClickSlotButton);
    }

    private void OnClickSlotButton()
    {
        sellButton.SetActive(true);
        slotsButtons.interactable = false;
    }    
}
