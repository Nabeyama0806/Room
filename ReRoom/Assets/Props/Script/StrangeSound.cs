using UnityEngine;

public class StrangeSound : Props
{
    [SerializeField] AudioClip m_sound;
    [SerializeField] float m_volume = 0.5f;

    private GameObject m_soundObject;

    protected override void StartExecute()
    {
        //ƒ‹[ƒvÄ¶
        m_soundObject = SoundManager.PlayLoop3D(m_sound, transform.position, m_volume);
        m_soundObject.transform.parent = transform;
    }

    private void FixedUpdate()
    {
        //ŒÅ’è‰»‚³‚ê‚½‚çÄ¶‚ğ’â~
        if (Type == ObjectType.Lock)
        {
            Destroy(m_soundObject);
        }
    }
}