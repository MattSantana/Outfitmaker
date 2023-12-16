using UnityEngine;

[CreateAssetMenu(fileName = "New Character Skeleton", menuName = "Character Skeleton")]
public class CharacterSkeleton : ScriptableObject
{
    [SerializeField] private BodyMember[] characterSkeletonMember;
}

[System.Serializable]
public class BodyMember
{
    [SerializeField] private string bodyPartName;
    [SerializeField] private BodyPart bodyPart;
}
