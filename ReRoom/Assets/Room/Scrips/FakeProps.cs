using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeProps : MonoBehaviour
{
    [SerializeField] List<GameObject> fakeProps;

    public void SetFakeProps()
    {
        //�S�ẴI�u�W�F�N�g���\���ɂ���
        foreach (var prop in fakeProps)
        {
            prop.SetActive(false);
        }

        //�����_����1�̃I�u�W�F�N�g��\������
        int randomIndex = Random.Range(0, fakeProps.Count);
        fakeProps[randomIndex].SetActive(true);
    }
}
