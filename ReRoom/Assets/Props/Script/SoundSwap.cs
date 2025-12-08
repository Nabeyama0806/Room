using UnityEngine;

public class SoundSwap : Props
{
    [SerializeField] AudioClip m_normalSound;
    [SerializeField] AudioClip m_anomalySound;
    [SerializeField] float m_volume = 0.25f;

    private AudioSource m_audio;
    private bool m_needsUpdate;

    private void Start()
    {
        //初期化
        m_needsUpdate = Type != ObjectType.Lock;

        //ループ再生
        AudioClip sound = Type == ObjectType.Anomaly ? m_anomalySound : m_normalSound;
        m_audio = SoundManager.PlayLoop3D(sound, transform.position, m_volume);
        m_audio.transform.parent = transform;

        //再生位置を取得
        m_audio.timeSamples = GameSceneManager.Instance.TimeSample;
    }

    private void Update()
    {
        //更新が必要なければ処理を行わない
        if (!m_needsUpdate) return;

        //固定オブジェクトでなければ処理を行わない
        if (Type != ObjectType.Lock) return;

        //オーディオの再生位置を保存
        GameSceneManager.Instance.TimeSample = m_audio.timeSamples;

        //更新不要に設定
        m_needsUpdate = false;
    }

    public override void Hit()
    {
        //自身が削除されることを通知
        GameSceneManager.Instance.DeleteObject(Type);

        //オーディオの再生位置を保存
        GameSceneManager.Instance.TimeSample = m_audio.timeSamples;

        //オブジェクトを非表示にする
        gameObject.SetActive(false);
    }
}