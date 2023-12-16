using System.Collections;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private int lettersPerSecond;
    
    //Singleton
    public static DialogManager Instance { get; private set ; }

    // Observers
    public delegate void OnPlayerInteract();
    public static OnPlayerInteract onPlayerInteract;
    public delegate void OnPlayerMovementDisable();
    public static OnPlayerMovementDisable onPlayerMovementDisable;

    private void Awake() {
        Instance = this;
    }
    public void ShowDialog(Dialog dialog)
    {
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(dialog.Lines[0]));
    }

    public IEnumerator TypeDialog(string line)
    {
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
    }


}
