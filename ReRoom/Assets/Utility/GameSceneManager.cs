using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    static private GameSceneManager m_instance;

    private const int MaxRoomIndex = 6;

    private List<int> m_indexList;
    private int m_currentRoomIndex;
    private int m_totalLoopCount;
    private int m_timeSample;
    private float m_playTime;
    private bool m_isPlaying;
    private bool m_isPaused;

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

    public bool IsPaused
    {
        get { return m_isPaused; }
        set { m_isPaused = value; }
    }

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_totalLoopCount = 0;
        m_currentRoomIndex = 1;
        m_isPlaying = true;
        m_isPaused = false;
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
        //オーキャン

        //値の初期化
        int index = 0;
        int value = 0;

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
        index = Random.Range(0, m_indexList.Count);

        //値を取得
        value = m_indexList[index];

        //リストから削除
        m_indexList.RemoveAt(index);

        return value;
    }

    private void Check()
    {
        //オーキャン

        //クリア回数に応じて処理を分岐
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

    public void DeleteObject(ObjectType type)
    {
        //ループ回数をカウント
        m_totalLoopCount++;

        //異変を削除したら部屋数を加算
        if (type == ObjectType.Anomaly)
        {
            m_currentRoomIndex++;
        }

        //クリアチェック
        Check();
    }
}