using UnityEngine;

public class Floating : AnomalyProps
{
    [SerializeField] float m_amplitude = 0.2f;       // •‚‚­‚‚³‚ÌÅ‘å•
    [SerializeField] float m_speedMin = 0.5f;        // •‚‚­‘¬“x‚ÌÅ¬
    [SerializeField] float m_speedMax = 1.5f;        // •‚‚­‘¬“x‚ÌÅ‘å
    [SerializeField] float m_rotationAmount = 5f;    // Œy‚­—h‚ê‚é‰ñ“]‚Ì•
    [SerializeField] float m_minHeight = 0.1f;       // ’n–Ê‚©‚ç‚ÌÅ¬‚‚³

    private Vector3 m_basePos;
    private float m_speed;
    private float m_offset;

    void Start()
    {
        //‰Šúİ’è
        m_basePos = transform.position;
        m_speed = Random.Range(m_speedMin, m_speedMax);
        m_offset = Random.Range(0f, Mathf.PI * 2f);
    }

    public override void UpdateExecute()
    {
        float t = Time.time * m_speed + m_offset;

        //ã‰º‚É•‚‚©‚¹‚é
        float y = Mathf.Sin(t) * m_amplitude;

        //‰ºŒÀ‚ğ’´‚¦‚È‚¢‚æ‚¤‚É•â³
        if (m_basePos.y + y < m_minHeight) y = m_minHeight - m_basePos.y;

        //‰ñ“]
        float rotZ = Mathf.Sin(t * 0.7f) * m_rotationAmount;

        transform.position = m_basePos + new Vector3(0, y, 0);
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
