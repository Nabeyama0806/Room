using TMPro;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] Props[] m_props;
    [SerializeField] TextMeshProUGUI m_uiRoomNumber;
    [SerializeField] DoorController m_door;

    public void SetAnomaly()
    {
        //異変を配置
        int index = Random.Range(0, m_props.Length);
        m_props[index].Type = ObjectType.Anomaly;

        //Debug.Log("[異変設置] 名前 : " + m_props[index].name);

        //部屋番号の表示
        m_uiRoomNumber.text = GameSceneManager.Instance.CurrentRoomIndex.ToString("D1");
    }

    public void DoorOpen()
    {
        m_door.CanOpen = true;
    }

    public void Lock()
    {
        foreach (var prop in m_props)
        {
            prop.Type = ObjectType.Lock;
        }
    }
}