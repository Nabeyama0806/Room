using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.GameCenter;

public class RoomCreate : MonoBehaviour
{
    [SerializeField] List<GameObject> m_fakeObjectList;
    [SerializeField] GameObject m_bottleParent;

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
            //同じものが選ばれないようにリストから削除しながら選択
            int index = Random.Range(0, list.Count);
            list[index].SetActive(true);
            list.RemoveAt(index);
        }

        //ボトルを配置
        m_bottleParent.GetComponent<BottleController>().SetBottle(fakeAmount);
    }
}