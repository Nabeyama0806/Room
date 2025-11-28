using UnityEngine;

public class Flicker : AnomalyProps
{
    [SerializeField] Renderer m_renderer;
    [SerializeField] float m_minInterval = 0.05f;   //点灯時間の最小
    [SerializeField] float m_maxInterval = 0.3f;    //点灯時間の最大

    private float m_timer;
    private float m_nextTime;

    void Start()
    {
        //自身のコンポーネントを取得
        m_renderer = GetComponent<Renderer>();

        //初期設定
        m_timer = 0f;
        m_nextTime = Random.Range(m_minInterval, m_maxInterval);
    }

    public override void UpdateExecute()
    {
        //点滅処理
        m_timer += Time.deltaTime;
        if (m_timer >= m_nextTime)
        {
            //点滅切り替え
            m_renderer.enabled = !m_renderer.enabled;

            //次の点滅時間をランダムで決定
            m_nextTime = Random.Range(m_minInterval, m_maxInterval);
            m_timer = 0f;
        }
    }
}
