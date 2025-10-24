using System.Collections.Generic;
using UnityEngine;

public class RoomCreate : MonoBehaviour
{
    [SerializeField] List<GameObject> m_fakeObjectList;
    [SerializeField] GameObject m_bottleParent;
    [SerializeField] GameObject m_doorParent;

    public void SetFake(int fakeAmount)
    {
        //全て非表示
        foreach (var fake in m_fakeObjectList)
        {
            fake.SetActive(false);
        }

        //偽物をランダムに配置
        List<GameObject> list = new List<GameObject>(m_fakeObjectList);
        for (int i = 0; i < fakeAmount; i++)
        {
            //ランダムに選ばれたオブジェクトを表示
            int index = Random.Range(0, list.Count);
            list[index].SetActive(true);
            list[index].GetComponent<FakeProps>().SetFakeProps();

            //同じものが選ばれないようにリストから削除
            list.RemoveAt(index);
        }

        //ボトルを配置
        m_bottleParent.GetComponent<BottleController>().SetBottle(fakeAmount);
    }

    public void SetDoorOpen()
    {
        m_doorParent.GetComponent<DoorParent>().OpenDoor();
    }
}