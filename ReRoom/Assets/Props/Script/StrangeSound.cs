using UnityEngine;

public class StrangeSound : Props
{
    [SerializeField] AudioClip m_sound;
    [SerializeField] float m_volume = 0.5f;

    private AudioSource m_audio;

    protected override void StartExecute()
    {
        //ループ再生
        m_audio = SoundManager.PlayLoop3D(m_sound, transform.position, m_volume);
        m_audio.transform.parent = transform;
    }

    public override void Lock()
    {
        //基底クラスの処理を実行
        base.Lock();

        //固定化されたら再生を停止
        Destroy(m_audio);
    }
}