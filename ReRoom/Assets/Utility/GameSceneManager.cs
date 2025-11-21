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
        //部屋番号の更新
        m_currentRoomIndex++;

        //本物を削除した場合は最初から
        if (type == ObjectType.Real)
        {
            m_currentRoomIndex = 1;
        }

        Debug.Log("現在の部屋番号 : " + m_currentRoomIndex);

        //部屋数の上限に達していればクリア
        if (m_currentRoomIndex >= MaxRoomIndex)
        {
            Debug.Log("ゲームクリア!!!!");
        }

        //新たに部屋を生成
        RoomGenerator.Instance.Create();
    }
}