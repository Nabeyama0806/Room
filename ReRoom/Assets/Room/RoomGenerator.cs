using Unity.VisualScripting;
using UnityEngine;

public class RoomGenerator : MonoBehaviour
{
    static RoomGenerator m_instance;

    [SerializeField] GameObject m_roomPrefab;

    private const int RoomWidth = 16;

    private int m_createIndex;

    static public RoomGenerator Instance�@=> m_instance;

    private void Awake()
    {
        //�V���O���g��
        if (m_instance == null) m_instance = this;

        //�����̕����𐶐�
        m_createIndex = 0;
        Create();
    }

    public void Create()
    {
        //����
        GameObject tmp = Instantiate(m_roomPrefab, new Vector3(0, 0, RoomWidth * m_createIndex), Quaternion.Euler(0, 180, 0));
        tmp.transform.parent = transform;
        m_createIndex++;

        //�Â��������폜
        if (m_createIndex > 3)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
    }
}
