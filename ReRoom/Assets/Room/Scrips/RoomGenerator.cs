using UnityEngine;
using System.Collections.Generic;

public class RoomGenerator : MonoBehaviour
{
    static RoomGenerator m_instance;

    [SerializeField] GameObject m_roomPrefab;

    private const int RoomWidth = 16;
    private const int MaxRoomNum = 3;

    private int m_createIndex;

    static public RoomGenerator Instance　=> m_instance;

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_createIndex = 0;
    }

    public void Create(int fakeAmount)
    {
        //部屋を生成
        GameObject room = Instantiate(m_roomPrefab, new Vector3(0, 0, RoomWidth * m_createIndex), Quaternion.Euler(0, 180, 0));
        room.transform.parent = transform;
        m_createIndex++;

        //偽物を配置
        room.GetComponent<RoomCreate>().SetFake(fakeAmount);

        //古い部屋を削除
        if (m_createIndex > MaxRoomNum)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
