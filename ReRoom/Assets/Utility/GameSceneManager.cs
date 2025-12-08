using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    static GameSceneManager m_instance;

    private const int MaxRoomIndex = 6;

    private List<int> m_indexList;
    private int m_currentRoomIndex;
    private int m_totalLoopCount;
    private int m_timeSample;
    private float m_playTime;
    private bool m_isPlaying;

    static public GameSceneManager Instance => m_instance;

    public int MaxRoom => MaxRoomIndex;

    public int CurrentRoomIndex => m_currentRoomIndex;

    public int TotalLoopCount => m_totalLoopCount;

    public float PlayTime => m_playTime;

    public int TimeSample
    { 
        get { return m_timeSample; }
        set { m_timeSample = value; }
    }

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_totalLoopCount = 0;
        m_currentRoomIndex = 1;
        m_isPlaying = true;
        m_indexList = new List<int>();
    }

    private void Start()
    {
        //部屋を生成
        RoomGenerator.Instance.Create(SelectIndex());
    }

    private void Update()
    {
        //プレイ中なら時間をカウント
        if (m_isPlaying)
        {
            m_playTime += Time.deltaTime;
        }
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
        //ループ回数をカウント
        m_totalLoopCount++;

        //正解したら次の部屋へ
        if (type == ObjectType.Anomaly)
        {
            m_currentRoomIndex++;
        }

        //クリア回数が最大値を超えているか
        if (m_currentRoomIndex > MaxRoomIndex)
        {
            //出口を生成
            RoomGenerator.Instance.Exit();

            //ゲームクリア
            m_isPlaying = false;
        }
        else 
        {
            //続きの部屋を生成
            RoomGenerator.Instance.Create(SelectIndex());
        }
    }
}