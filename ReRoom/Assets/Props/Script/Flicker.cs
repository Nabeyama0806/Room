using UnityEngine;

public class Flicker : AnomalyProps
{
    [SerializeField] GameObject m_target;
    [SerializeField] float m_minInterval = 0.05f;
    [SerializeField] float m_maxInterval = 0.2f;

    private float m_timer;
    private float m_nextTime;

    void Start()
    {
        m_timer = 0f;
        m_nextTime = Random.Range(m_minInterval, m_maxInterval);
    }

    public override void UpdateExecute()
    {
        m_timer += Time.deltaTime;

        if (m_timer >= m_nextTime)
        {
            //“_–Å
            m_target.SetActive(!m_target.activeSelf);

            m_nextTime = Random.Range(m_minInterval, m_maxInterval);
            m_timer = 0f;
        }
    }
}
