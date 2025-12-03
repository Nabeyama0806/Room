using System.Collections.Generic;
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

    private const int MaxRoomIndex = 2;
    private List<int> m_indexList;
    private int m_currentRoomIndex;

    public int CurrentRoomIndex => m_currentRoomIndex;

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_currentRoomIndex = 1;
        m_indexList = new List<int>();
    }

    private void Start()
    {
        //最初の部屋を生成
        RoomGenerator.Instance.Initialize();

        //次の部屋を生成
        RoomGenerator.Instance.Create(SelectIndex());
    }

    private int SelectIndex()
    {
        //リストが空なら初期化
        if (m_indexList.Count == 0)
        {
            int count = RoomGenerator.Instance.PropsIndex;
            m_indexList = new List<int>(count);

            for (int i = 0; i < count; i++)
            {
                m_indexList.Add(i);
            }
        }

        //ランダムで選択
        int index = Random.Range(0, m_indexList.Count);

        //値を取得
        int value = m_indexList[index];

        //リストから削除
        m_indexList.RemoveAt(index);

        return value;
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
            RoomGenerator.Instance.Create(SelectIndex());
        }
    }
}