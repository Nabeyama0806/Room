using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class RoomGenerator : MonoBehaviour
{
    static RoomGenerator m_instance;

    [SerializeField] GameObject m_firstRoom;
    [SerializeField] GameObject m_roomPrefab;

    private const int RoomWidth = 32;
    private const int MaxRoomNum = 2;

    private int m_createIndex;

    static public RoomGenerator Instance　=> m_instance;

    public int CreateRoomIndex => m_createIndex;

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期化
        m_createIndex = 0;
    }

    public void Create(int fakeAmount, bool isFirst = false)
    {
        Debug.Log("偽物を [" + fakeAmount + "] 個生成");

        //現在の部屋のドアを開ける
        if (m_createIndex > 0)
        {
            transform.GetChild(m_createIndex == 1 ? 0 : transform.childCount - 1).GetComponent<RoomCreate>().SetDoorOpen();
        }

        //部屋を生成
        GameObject roomPrefab = isFirst ? m_firstRoom : m_roomPrefab;
        GameObject room = Instantiate(roomPrefab, new Vector3(0, 0, RoomWidth * m_createIndex), Quaternion.Euler(0, 180, 0));
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