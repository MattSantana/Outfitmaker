using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialog
{
    [SerializeField] private List<string> dialogLines;
    [SerializeField] private GameObject interacticeInterface;

    public List<string> Lines{
        get{ return dialogLines; }
    }

    public GameObject InteractiveInterface {
        get{ return interacticeInterface ; }
    }
}
