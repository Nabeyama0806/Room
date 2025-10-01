using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverController : MonoBehaviour
{
    [SerializeField] AudioClip m_shotSound;
    [SerializeField] GameObject m_effect;

    public void Shot()
    {
        //���ʉ��̍Đ�
        SoundManager.Play2D(m_shotSound);

        //�G�t�F�N�g�̍Đ�
        StartCoroutine(ShotEffect());
    }

    private IEnumerator ShotEffect()
    {
        //�G�t�F�N�g��\��
        m_effect.SetActive(true);

        //�����ҋ@
        yield return new WaitForSeconds(0.06f);

        //�G�t�F�N�g���\��
        m_effect.SetActive(false);
    }
}
