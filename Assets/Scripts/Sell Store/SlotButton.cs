using UnityEngine;
using UnityEngine.UI;

public class SlotButton : MonoBehaviour
{
    [SerializeField] private Button slotsButtons;
    [SerializeField] private GameObject sellButton;
    [SerializeField] private AudioSource audioSource;
    void Start()
    {
        slotsButtons.onClick.AddListener(OnClickSlotButton);
    }

    private void OnClickSlotButton()
    {
        audioSource.Play();
        sellButton.SetActive(true);
        slotsButtons.interactable = false;
    }    
}
