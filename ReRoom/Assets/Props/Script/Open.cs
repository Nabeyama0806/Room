using UnityEngine;

public class Open : Props
{
    [SerializeField] Transform m_targetPos;
    [SerializeField] GameObject m_door;
    [SerializeField] float m_speed = 0.03f;

    private Vector3 m_startPos;
    private float t = 0f;

    void Start()
    {
        m_startPos = m_door.transform.localPosition;
    }

    protected override void UpdateExecute()
    {
        //ドアを少しずつ横にスライドさせる
        if (t < 1f)
        {
            t += Time.deltaTime * m_speed;
            m_door.transform.localPosition =
                Vector3.Lerp(m_startPos, m_targetPos.localPosition, t);
        }
    }
}
