using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizer : MonoBehaviour
{
    [SerializeField] private CharacterSkeleton charSkeleton;
    [SerializeField] private BodyPartSelection[] bodyPartSelections;
    void Start()
    {
       for (int i = 0; i < bodyPartSelections.Length; i++) 
       {
            GetCurrentBodyParts(i);
       }
    }

    private void GetCurrentBodyParts(int i)
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class BodyPartSelection
{
    [SerializeField] private string bodyPartName;
    [SerializeField] private BodyPart bodyPartOptions;
    //[SerializeField] private Text bodyPartNameTextComponent;
    [HideInInspector] public int bodyPartCurrentIndex;
}