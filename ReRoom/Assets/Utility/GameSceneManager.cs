using TMPro;
using UnityEngine;

enum TextType
{ 
    DeleteCount,
    RoomCount,
    PlayTime,

    Length,
}

public class GameSceneManager : MonoBehaviour
{
    static GameSceneManager m_instance;

    [SerializeField] PlayData m_playData;
    [SerializeField] TextMeshProUGUI[] m_texts = new TextMeshProUGUI[(int)TextType.Length];

    private const int MaxFakeAmount = 6;  //生成する偽物の最大数

    private int m_fakeAmount;       //生成する偽物の数
    private int m_deleteAmount;     //削除した偽物の数

    private int m_totalDeleteAmount;      //削除した偽物の総数
    private int m_totalRoomNumber;        //進んだ部屋の総数
    private float m_totalPlayTime;        //プレイ時間

    static public GameSceneManager Instance => m_instance;

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_fakeAmount = 0;
        m_deleteAmount = 0;

        m_totalDeleteAmount = 0;
        m_totalRoomNumber = 0;
        m_totalPlayTime = 0.0f;
    }

    private void Start()
    {
        //最初の部屋を生成
        SetRoom();
    }

    private void Update()
    {
        //プレイ時間を加算
        m_totalPlayTime += Time.deltaTime;

        //UIの更新
        m_texts[(int)TextType.DeleteCount].text = $"Delete: {m_totalDeleteAmount}";
        m_texts[(int)TextType.RoomCount].text = $"Room: {m_totalRoomNumber}";
        m_texts[(int)TextType.PlayTime].text = $"Time: {m_totalPlayTime:F1}s";
    }

    private void SetRoom()
    {
        //偽物の数をランダムに決定
        m_fakeAmount = Random.Range(1, MaxFakeAmount + 1);

        //部屋を生成
        RoomGenerator.Instance.Create(m_fakeAmount);
    }

    public void DeleteFake()
    {
        //削除した偽物の数を加算
        m_deleteAmount++;
        m_totalDeleteAmount++;

        //全ての偽物を削除したら扉を開けて次の部屋へ
        if (m_deleteAmount >= m_fakeAmount)
        {
            m_deleteAmount = 0;
            m_totalRoomNumber++;
            SetRoom();

            Debug.Log("次の部屋へ");
        }
    }

    public void GameOver()
    {
        //リザルトの上書き
        m_playData.deleteFakeCount = m_totalDeleteAmount;
        m_playData.roomNumber = m_totalRoomNumber;
        m_playData.playTime = m_totalPlayTime;

        //リザルト画面へ遷移
        SceneController.Transition(SceneType.Game, SceneType.Result);
    }
}