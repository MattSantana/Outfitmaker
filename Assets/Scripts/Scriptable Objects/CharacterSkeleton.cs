using UnityEngine;

[CreateAssetMenu(fileName = "New Character Skeleton", menuName = "Character Skeleton")]
public class CharacterSkeleton : ScriptableObject
{
    [SerializeField] private BodyMember[] characterSkeletonMember;
    public BodyMember[] CharSkeletonMembers{
        get{ return characterSkeletonMember ; }
    }
}

[System.Serializable]
public class BodyMember
{
    [SerializeField] private string bodyPartName;
    public BodyPart bodyPart;

}
