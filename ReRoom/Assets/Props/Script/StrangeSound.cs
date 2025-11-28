using UnityEngine;

public class StrangeSound : AnomalyProps
{
    [SerializeField] AudioClip m_sound;

    private GameObject m_soundObject;

    public override void StartExecute()
    {
        //ƒ‹[ƒvÄ¶
        m_soundObject = SoundManager.PlayLoop3D(m_sound, transform.position);
        m_soundObject.transform.parent = transform;
    }
}
