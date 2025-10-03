using System.Collections.Generic;
using UnityEngine;

public class RoomCreate : MonoBehaviour
{
    [SerializeField] List<GameObject> m_fakeObjectList;
    [SerializeField] GameObject m_bottleParent;

    public void SetFake(int fakeAmount)
    {
        //�S�Ĕ�\��
        foreach (var fake in m_fakeObjectList)
        {
            fake.SetActive(false);
        }

        //�U���������_���ɔz�u
        List<GameObject> list = new List<GameObject>(m_fakeObjectList);
        for (int i = 0; i < fakeAmount; i++)
        {
            //�����_���ɑI�΂ꂽ�I�u�W�F�N�g��\��
            int index = Random.Range(0, list.Count);
            list[index].SetActive(true);
            list[index].GetComponent<FakeProps>().SetFakeProps();

            //�������̂��I�΂�Ȃ��悤�Ƀ��X�g����폜���Ȃ���I��
            list.RemoveAt(index);
        }

        //�{�g����z�u
        m_bottleParent.GetComponent<BottleController>().SetBottle(fakeAmount);
    }
}