using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeProps : MonoBehaviour
{
    [SerializeField] List<GameObject> fakeProps;

    public void SetFakeProps()
    {
        //全てのオブジェクトを非表示にする
        foreach (var prop in fakeProps)
        {
            prop.SetActive(false);
        }

        //ランダムに1つのオブジェクトを表示する
        int randomIndex = Random.Range(0, fakeProps.Count);
        fakeProps[randomIndex].SetActive(true);
    }
}
