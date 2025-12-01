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

    private void FixedUpdate()
    {
        //ŒÅ’è‰»‚³‚ê‚½‚çÄ¶‚ğ’â~
        if (Type == ObjectType.Lock)
        {
            Destroy(m_soundObject);
        }
    }
}