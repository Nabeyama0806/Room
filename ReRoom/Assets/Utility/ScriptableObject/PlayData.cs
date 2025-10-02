using UnityEngine;

[CreateAssetMenu(fileName = "New PlayData", menuName = "ScriptableObject/PlayData")]
public class PlayData : ScriptableObject
{
    public int deleteFakeCount; //削除したオブジェクト数
    public int roomNumber;      //進んだ部屋数
    public float playTime;      //プレイ時間
}
