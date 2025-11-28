using TMPro;
using UnityEngine;

enum TextType
{ 
    DeleteCount,
    RoomCount,

    Length,
}

public class GameSceneManager : MonoBehaviour
{
    static GameSceneManager m_instance;

    static public GameSceneManager Instance => m_instance;

    private const int MaxRoomIndex = 6;
    private int m_currentRoomIndex;

    public int CurrentRoomIndex => m_currentRoomIndex;

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_currentRoomIndex = 1;
    }

    private void Start()
    {
        //最初の部屋を生成
        RoomGenerator.Instance.Initialize();
    }

    public void DeleteObject(ObjectType type)
    {
        //正解したら次の部屋へ
        if(type == ObjectType.Anomaly)
        {
            m_currentRoomIndex++;
        }

        //部屋数の上限に達しているか
        if (m_currentRoomIndex > MaxRoomIndex)
        {
            //最後の部屋を生成
            RoomGenerator.Instance.Innermost();
        }
        else 
        {
            //続きの部屋を生成
            RoomGenerator.Instance.Create();
        }
    }
}