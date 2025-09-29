using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeBottle : MonoBehaviour
{
    [SerializeField] GameObject[] m_bottles;

    private void Awake()
    {
        //全て非表示
        foreach (var bottle in m_bottles)
        {
            bottle.SetActive(false);
        }

        //ランダムな数だけ表示
        int count = Random.Range(1, m_bottles.Length);
        for (int i = 0; i < count; ++i)
        { 
            m_bottles[i].SetActive(true);
        }
    }
}
