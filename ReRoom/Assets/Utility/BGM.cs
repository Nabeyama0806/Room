using System;
using UnityEngine;
using System.Collections.Generic;

public class BGM : MonoBehaviour
{
    static private BGM m_instance;

    static public BGM Instance
    {
        get { return m_instance; }
    }


    [Serializable]
    public class SoundData
    {
        public SceneType type; 
        public AudioClip sound;
        public float volume; 
    }

    [SerializeField] List<SoundData> m_soundList; 

    private Dictionary<SceneType, AudioClip> m_soundDataList;
    private AudioSource m_audioSource;

    private void Awake()
    {
        m_instance = this;
        m_audioSource = GetComponent<AudioSource>();
        m_soundDataList = new Dictionary<SceneType, AudioClip>();

        //BGM�ƃX�e�[�W��R�Â��邽�߂̘A�z�z�񃊃X�g���쐬
        foreach (var sound in m_soundList)
        {
            m_soundDataList.Add(sound.type, sound.sound);
        }
    }

    public void Play(SceneType type)
    {
        //BGM���o�^����Ă��Ȃ���Ή������Ȃ�
        if (m_soundDataList[type] == null) return;

        //BGM�̕t���ւ�
        m_audioSource.clip = m_soundDataList[type];

        //���ʂ̒���
        m_audioSource.volume = m_soundList[(int)type].volume;

        m_audioSource.Play();
    }

    public void Stop()
    {
        m_audioSource.Stop();
    }
}