using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverController : MonoBehaviour
{
    [SerializeField] AudioClip m_shotSound;
    [SerializeField] GameObject m_shotEffect;
    [SerializeField] GameObject m_hitEffect;

    public void Shot(Vector3 position)
    {
        //���ʉ��̍Đ�
        SoundManager.Play2D(m_shotSound);

        //�G�t�F�N�g�̍Đ�
        StartCoroutine(ShotEffect());
        StartCoroutine(HitEffect(position));
    }

    private IEnumerator ShotEffect()
    {
        //�G�t�F�N�g��\��
        m_shotEffect.SetActive(true);

        //�����ҋ@
        yield return new WaitForSeconds(0.06f);

        //�G�t�F�N�g���\��
        m_shotEffect.SetActive(false);
    }

    private IEnumerator HitEffect(Vector3 position)
    {
        //�G�t�F�N�g�̕\��
        m_hitEffect.transform.position = position;
        m_hitEffect.SetActive(true);

        //�����ҋ@
        yield return new WaitForSeconds(0.1f);

        //�G�t�F�N�g���폜
        m_hitEffect.SetActive(false);
    }
}
