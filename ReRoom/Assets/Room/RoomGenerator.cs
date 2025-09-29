using Unity.VisualScripting;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    static RoomGenerator m_instance;

    [SerializeField] GameObject m_roomPrefab;

    private const int RoomWidth = 16;

    private int m_createIndex;

    static public RoomGenerator Instance　=> m_instance;

    private void Awake()
    {
        //シングルトン
        if (m_instance == null) m_instance = this;

        //初期の部屋を生成
        m_createIndex = 0;
        Create();
    }

    public void Create()
    {
        //生成
        GameObject tmp = Instantiate(m_roomPrefab, new Vector3(0, 0, RoomWidth * m_createIndex), Quaternion.Euler(0, 180, 0));
        tmp.transform.parent = transform;
        m_createIndex++;

        //古い部屋を削除
        if (m_createIndex > 3)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
