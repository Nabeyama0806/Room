using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBottle : MonoBehaviour
{
    [SerializeField] GameObject[] m_bottles;

    private void Awake()
    {
        //�S�Ĕ�\��
        foreach (var bottle in m_bottles)
        {
            bottle.SetActive(false);
        }

        //�����_���Ȑ������\��
        int count = Random.Range(1, m_bottles.Length);
        for (int i = 0; i < count; ++i)
        { 
            m_bottles[i].SetActive(true);
        }
    }
}
