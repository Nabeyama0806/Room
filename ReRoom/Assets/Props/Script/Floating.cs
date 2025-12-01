using UnityEngine;

public class Floating : AnomalyProps
{
    [SerializeField] float m_amplitude = 0.2f;      // 上下の幅
    [SerializeField] float m_speedMin = 0.5f;       // 最小速度
    [SerializeField] float m_speedMax = 1.5f;       // 最大速度
    [SerializeField] float m_floatHeight = 0.5f;    // 地面からどれだけ浮かせるか

    [SerializeField] float m_rotSpeedMin = 10f;     // 回転速度(最小)
    [SerializeField] float m_rotSpeedMax = 30f;     // 回転速度(最大)
    [SerializeField] float m_rotNoise = 10f;        // ゆらぎ回転（ランダムなブレ）

    private Vector3 m_basePos;
    private float m_speed;
    private float m_offset;
    private Vector3 m_rotSpeed;

    void Start()
    {
        //初期の浮遊位置を設定
        m_basePos = transform.position + new Vector3(0, m_floatHeight, 0);

        m_speed = Random.Range(m_speedMin, m_speedMax);
        m_offset = Random.Range(0f, Mathf.PI * 2f);

        //各軸に微妙なランダム回転速度を付与
        float s = Random.Range(m_rotSpeedMin, m_rotSpeedMax);
        m_rotSpeed = new Vector3(
            Random.Range(-s, s),
            Random.Range(-s, s),
            Random.Range(-s, s)
        );
    }

    public override void UpdateExecute()
    {
        float t = Time.time * m_speed + m_offset;

        //上下にふわふわ移動
        float y = Mathf.Sin(t) * m_amplitude;

        //宙に固定しつつ上下動
        transform.position = m_basePos + new Vector3(0, y, 0);

        //ノイズ的な微妙な揺らぎ
        Vector3 noise = new Vector3(
            Mathf.Sin(t * 1.2f) * m_rotNoise,
            Mathf.Cos(t * 1.1f) * m_rotNoise,
            Mathf.Sin(t * 0.9f) * m_rotNoise
        );

        transform.Rotate((m_rotSpeed + noise) * Time.deltaTime);
    }
}
