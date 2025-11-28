using UnityEngine;

public class RoomCreate : MonoBehaviour
{
    [SerializeField] GameObject[] m_fakeObjectList;
    [SerializeField] Props[] m_props;
    [SerializeField] GameObject m_bottleParent;
    [SerializeField] DoorController m_door;

    public void SetFake()
    {
        //全て非表示
        foreach (var fake in m_fakeObjectList)
        {
            fake.SetActive(false);
        }

        //偽物を配置
        int index = Random.Range(0, m_fakeObjectList.Length);
        m_fakeObjectList[index].SetActive(true);
        m_fakeObjectList[index].GetComponent<FakeProps>().SetFakeProps();

        //ボトルを配置
        m_bottleParent.GetComponent<BottleController>().SetBottle();
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