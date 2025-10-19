using UnityEngine;

public class PropsCreate : MonoBehaviour
{
    private void Awake()
    {
        //子オブジェクトをすべて非表示にする
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }

        //ランダムに1つだけ表示する
        int randomIndex = Random.Range(0, transform.childCount);
        transform.GetChild(randomIndex).gameObject.SetActive(true);
    }
}
