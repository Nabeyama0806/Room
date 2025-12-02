using TMPro;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] Props[] m_normalProps;
    [SerializeField] Props[] m_anomalyProps;
    [SerializeField] TextMeshProUGUI m_uiRoomNumber;
    [SerializeField] DoorController m_door;

    public void SetAnomaly()
    {
        //àŸïœÇîzíu
        int index = Random.Range(0, m_anomalyProps.Length);
        m_anomalyProps[index].Type = ObjectType.Anomaly;

        //ïîâÆî‘çÜÇÃï\é¶
        m_uiRoomNumber.text = GameSceneManager.Instance.CurrentRoomIndex.ToString("D1");
    }

    public void DoorOpen()
    {
        m_door.CanOpen = true;
    }

    public void Lock()
    {
        foreach (var prop in m_normalProps)
        {
            prop.Type = ObjectType.Lock;
        }

        foreach (var prop in m_anomalyProps)
        {
            prop.Type = ObjectType.Lock;
        }
    }
}