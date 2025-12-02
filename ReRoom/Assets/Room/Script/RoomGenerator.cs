using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    static RoomGenerator m_instance;

    [SerializeField] GameObject m_roomPrefab;
    [SerializeField] GameObject m_firstRoom;
    [SerializeField] GameObject m_innermostRoom;

    private const int RoomWidth = 16;
    private const int MaxRoomNum = 3;

    private int m_createCount;

    static public RoomGenerator Instance　=> m_instance;

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_createCount = 0;
    }

    public void Initialize()
    {
        //最初の部屋を生成
        GameObject room = Instantiate(m_roomPrefab, new Vector3(0, 0, RoomWidth * m_createCount), Quaternion.Euler(0, 180, 0));
        room.transform.parent = transform;
        m_createCount++;

        //次の部屋を生成
        Create();
    }

    public void Create()
    {
        //現在の部屋を取得
        int roomIndex = m_createCount <= MaxRoomNum ? m_createCount - 1 : MaxRoomNum - 1;
        GameObject room = transform.GetChild(roomIndex).gameObject;
        if (room.TryGetComponent(out RoomController roomCreate))
        {
            //オブジェクトを固定する
            roomCreate.Lock();

            //現在の部屋のドアを開ける
            room.GetComponent<RoomController>().DoorOpen();
        }

        //新たに部屋を生成
        room = Instantiate(m_roomPrefab, new Vector3(0, 0, RoomWidth * m_createCount), Quaternion.Euler(0, 180, 0));
        room.transform.parent = transform;
        m_createCount++;

        //異変を配置
        room.GetComponent<RoomController>().SetAnomaly();

        //古い部屋を削除
        if (transform.childCount > MaxRoomNum)
        {
           Destroy(transform.GetChild(0).gameObject);
        }
    }

    public void Innermost()
    {
        //部屋のドアを開ける
        transform.GetChild(transform.childCount - 1).GetComponent<RoomController>().DoorOpen();

        //新たに部屋を生成
        Instantiate(m_innermostRoom, new Vector3(0, 0, RoomWidth * m_createCount), Quaternion.Euler(0, 180, 0));
    }
}