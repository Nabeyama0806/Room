using UnityEngine;

public class RoomController : MonoBehaviour
{
    [SerializeField] Props[] m_props;
    [SerializeField] BottleController m_bottleParent;
    [SerializeField] DoorController m_door;

    public void SetAnomaly()
    {
        //異変を配置
        int index = Random.Range(0, m_props.Length);
        m_props[index].Type = ObjectType.Anomaly;

        //ボトルを配置
        m_bottleParent.SetBottle();
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