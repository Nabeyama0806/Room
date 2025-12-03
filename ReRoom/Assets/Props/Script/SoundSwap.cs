using UnityEngine;

public class SoundSwap : Props
{
    [SerializeField] AudioClip m_normalSound;
    [SerializeField] AudioClip m_anomalySound;
    [SerializeField] float m_volume = 0.25f;

    private GameObject m_soundObject;

    private void Start()
    {
        //ループ再生
        AudioClip sound = Type == ObjectType.Anomaly ? m_anomalySound : m_normalSound;
        m_soundObject = SoundManager.PlayLoop3D(sound, transform.position, m_volume);
        m_soundObject.transform.parent = transform;
    }

    private void OnDestroy()
    {
        //オブジェクトが削除されたら音も停止
        if (m_soundObject != null)
        {
            Destroy(m_soundObject);
        }
    }
}
