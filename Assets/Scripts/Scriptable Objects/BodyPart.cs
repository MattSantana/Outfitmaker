using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "Body Part")]
public class BodyPart : ScriptableObject
{
    [SerializeField] private string bodyPartName;
    [SerializeField] private int bodyPartAnimationIndex;
    [SerializeField] private List<AnimationClip> allAnimationsRegardingThisBodyPart = new List<AnimationClip>();
}
