using UnityEngine;

public class Appearance : Props
{
    [SerializeField] GameObject[] m_object;

    protected override void StartExecute()
    {
        //当たり判定を有効化
        GetComponent<Collider>().enabled = true;

        //オブジェクトを表示する
        foreach (var obj in m_object)
        {
            obj.SetActive(true);
        }
    }
}
