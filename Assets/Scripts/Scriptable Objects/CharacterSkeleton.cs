using UnityEngine;

[CreateAssetMenu(fileName = "New Character Skeleton", menuName = "Character Skeleton")]
public class CharacterSkeleton : ScriptableObject
{
    public BodyMember[] characterSkeletonMember;

}

[System.Serializable]
public class BodyMember
{
    [SerializeField] private string bodyPartName;
    public BodyPart bodyPart;

}
