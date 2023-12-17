using System.Collections;
using UnityEngine;
using TMPro;
using System;
using UnityEditor;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogBox;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private int lettersPerSecond;
    private int currentLine = 0;
    private Dialog dialog;
    public Dialog DialogInstance {
        get{ return dialog ; }
    }
    private bool isTyping;
    
    //Singleton
    public static DialogManager Instance { get; private set ; }

    // Observers
    public delegate void OnPlayerInteract();
    public static OnPlayerInteract onPlayerInteract;
    public delegate void OnPlayerMovementDisable();
    public static OnPlayerMovementDisable onPlayerMovementDisable;

    // Events
    public event Action onClosingDialog;

    private void Awake() {
        Instance = this;
    }
    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        this.dialog = dialog;
        dialogBox.SetActive(true);
        if(!isTyping)
        {
            if(currentLine < dialog.Lines.Count && dialog.InteractiveInterface)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
                currentLine++;
            }
            else if( currentLine == dialog.Lines.Count && dialog.InteractiveInterface )
            {
                Debug.Log("entrei aqui");
                dialog.InteractiveInterface.SetActive(true);
                currentLine++;
            }
            else
            {
                ClosingDialog(dialog);
            }
        }
    }

    public void ClosingDialog(Dialog dialog)
    {
        currentLine = 0;
        onClosingDialog?.Invoke();
        dialog.InteractiveInterface.SetActive(false);
        dialogBox.SetActive(false);
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = "";
        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / lettersPerSecond);
        }
        isTyping = false;
    }


}
