using System;
using TMPro;
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

    public void NextBodyPart(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex < bodyPartSelections[partIndex].bodyPartOptions.Length - 1)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex++;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = 0;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    public void PreviousBody(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex > 0)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex--;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = bodyPartSelections[partIndex].bodyPartOptions.Length - 1;
            }

            UpdateCurrentPart(partIndex);
        }  
    }

    private bool ValidateIndexValue(int partIndex)
    {
        if (partIndex > bodyPartSelections.Length || partIndex < 0)
        {
            Debug.Log("Index value does not match any body parts!");
            return false;
        }
        else
        {
            return true;
        }
    }

    private void GetCurrentBodyParts(int partIndex)
    {   
        //get item price text
        bodyPartSelections[partIndex].bodyPartPriceTextComponent.text = "Cost: " + charSkeleton.characterSkeletonMember[partIndex].bodyPart.itemPriceCost.ToString() + " coins";
        // Get Current Body Part Animation ID
        bodyPartSelections[partIndex].bodyPartCurrentIndex = charSkeleton.characterSkeletonMember[partIndex].bodyPart.bodyPartAnimationIndex;
    }

    private void UpdateCurrentPart(int partIndex)
    {
        //update text price
        bodyPartSelections[partIndex].bodyPartPriceTextComponent.text = "Cost: " + bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex].itemPriceCost.ToString() + " coins";
        // Update Character Body Part
        charSkeleton.characterSkeletonMember[partIndex].bodyPart = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex];
    }
}

[System.Serializable]
public class BodyPartSelection
{
    public string bodyPartName;
    public BodyPart[] bodyPartOptions;

    public TextMeshProUGUI bodyPartPriceTextComponent;
    [HideInInspector] public int bodyPartCurrentIndex;
}