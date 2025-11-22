using UnityEngine;

public class RoomCreate : MonoBehaviour
{
    [SerializeField] GameObject[] m_fakeObjectList;
    [SerializeField] GameObject[] m_bottleParent;
    [SerializeField] GameObject m_doorParent;

    public void SetFake(int bottleAmount)
    {
        //全て非表示
        foreach (var fake in m_fakeObjectList)
        {
            fake.SetActive(false);
        }

        //偽物をランダムに配置
        int index = Random.Range(0, m_fakeObjectList.Length);
        m_fakeObjectList[index].SetActive(true);
        m_fakeObjectList[index].GetComponent<FakeProps>().SetFakeProps();

        //ボトルを配置
        foreach (var bottleParent in m_bottleParent)
        { 
            bottleParent.GetComponent<BottleController>().SetBottle(bottleAmount);
        }
    }

    public void SetDoorOpen()
    {
        m_doorParent.GetComponent<DoorParent>().OpenDoor();
    }

    public void ChangeTags(Transform parent)
    {
        foreach (Transform child in parent)
        {
            //子オブジェクトのタグを変更
            child.tag = gameObject.tag;

            //さらにその子オブジェクトもタグを変更    
            ChangeTags(child);
        }
    }
}