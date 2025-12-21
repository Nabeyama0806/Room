using UnityEngine;

public class Small : Props
{
    [SerializeField, Range(0.5f, 0.9f)] float m_scale = 0.8f;

    protected override void StartExecute()
    {
        //スケール変更
        transform.localScale *= m_scale;
    }
}