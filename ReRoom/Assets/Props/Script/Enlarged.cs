using UnityEngine;

public class Enlarged : AnomalyProps
{
    [SerializeField] float m_maxScale = 1.8f;
    [SerializeField] float m_speed = 0.02f;

    private float t = 0f;
    private Vector3 startScale;
    private Vector3 targetScale;

    private void Start()
    {
        startScale = transform.localScale;
        targetScale = startScale * m_maxScale;
    }

    public override void UpdateExecute()
    {
        if (t >= 1f) return;

        t += Time.deltaTime * m_speed;
        transform.localScale = Vector3.Lerp(startScale, targetScale, t);
    }
}
