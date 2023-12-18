using UnityEngine;
using UnityEngine.UI;

public class InteractiveInterfaceController : MonoBehaviour
{
    [SerializeField] private Button yesBtn;
    [SerializeField] private Button noBtn;

    [SerializeField] private GameObject storePanel;
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private GameObject interactiveInterface;
    [SerializeField] private AudioSource audioSource;
    private void Awake() {
        yesBtn.onClick.AddListener( OnYesButtonPlayClick );
        noBtn.onClick.AddListener( OnNoButtonPlayClick );
    }

    private void OnYesButtonPlayClick()
    {
        audioSource.Play();
        storePanel.SetActive(true);
        interactiveInterface.SetActive(false);
        dialogBox.SetActive(false);
    }
    private void OnNoButtonPlayClick()
    {
        audioSource.Play();
        DialogManager.Instance.ClosingDialog(DialogManager.Instance.DialogInstance);
    }
}
