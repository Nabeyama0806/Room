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

    [SerializeField] PlayData m_playData;
    [SerializeField] TextMeshProUGUI[] m_texts = new TextMeshProUGUI[(int)TextType.Length];

    private const int MaxRoomAmount = 6;  //生成する偽物の最小数

    private int m_createRoomIndex;      //生成した部屋のインデックス
    private int m_fakeAmount;           //生成する偽物の数
    private int m_deleteAmount;         //削除する偽物の数

    private int m_totalDeleteAmount;    //削除した偽物の総数
    private int m_totalRoomNumber;      //進んだ部屋の総数
    private float m_totalPlayTime;      //プレイ時間

    private bool m_isMistake;          //失敗判定

    static public GameSceneManager Instance => m_instance;

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_createRoomIndex = 0;
        m_fakeAmount = 0;
        m_deleteAmount = 0;

        m_totalDeleteAmount = 0;
        m_totalRoomNumber = 1;
        m_totalPlayTime = 0.0f;

        m_isMistake = false;
    }

    private void Start()
    {
        //最初の部屋を生成
        SetRoom(true);
    }

    private void FixedUpdate()
    {
        //プレイ時間を加算
        m_totalPlayTime += Time.deltaTime;

        //UIの更新
        m_texts[(int)TextType.DeleteCount].text = m_deleteAmount.ToString();
        m_texts[(int)TextType.RoomCount].text = m_totalRoomNumber.ToString();
    }

    private void SetRoom(bool isFirst = false)
    {
        //生成した部屋数の更新
        m_createRoomIndex++;

        //クリア判定
        if (m_createRoomIndex > MaxRoomAmount)
        {
            Completion();
        }

        //失敗していれば初めから
        if (m_isMistake)
        {
            m_createRoomIndex = 1;
            m_isMistake = false;
        }

        //部屋の生成
        RoomGenerator.Instance.Create(m_createRoomIndex, isFirst);
    }

    public void DeleteObject(ObjectType type)
    {
        //本物を削除した場合は失敗判定を立てる
        if(type == ObjectType.Real) 
        {
            m_isMistake = true;
        }

        //削除したオブジェクトの数を加算
        m_deleteAmount++;
        m_totalDeleteAmount++;

        //指定の数だけオブジェクトを削除したら扉を開けて次の部屋へ
        if (m_deleteAmount >= m_createRoomIndex)
        {
            m_deleteAmount = 0;
            m_totalRoomNumber++;
            SetRoom();

            Debug.Log("次の部屋へ");
        }
    }

    private void Completion()
    {
        //リザルトの上書き
        m_playData.deleteFakeCount = m_totalDeleteAmount;
        m_playData.roomNumber = m_totalRoomNumber;
        m_playData.playTime = m_totalPlayTime;

        //リザルト画面へ遷移
        SceneController.Transition(SceneType.Game, SceneType.Result);
    }
}