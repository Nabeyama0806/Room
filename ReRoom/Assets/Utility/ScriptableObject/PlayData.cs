using UnityEngine;

[CreateAssetMenu(fileName = "New PlayData", menuName = "ScriptableObject/PlayData")]
public class PlayData : ScriptableObject
{
    public int deleteFakeCount; //�폜�����I�u�W�F�N�g��
    public int roomNumber;      //�i�񂾕�����
    public float playTime;      //�v���C����
}
