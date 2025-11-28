using UnityEngine;

public class Duplicate : AnomalyProps
{
    [SerializeField] GameObject[] m_object;

    public override void StartExecute()
    {
        //オブジェクトを表示する
        foreach (var obj in m_object)
        {
            obj.SetActive(true);
        }
    }
}
