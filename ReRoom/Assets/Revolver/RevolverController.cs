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
        //効果音の再生
        SoundManager.Play2D(m_shotSound);

        //エフェクトの再生
        StartCoroutine(ShotEffect());
        StartCoroutine(HitEffect(position));
    }

    private IEnumerator ShotEffect()
    {
        //エフェクトを表示
        m_shotEffect.SetActive(true);

        //少し待機
        yield return new WaitForSeconds(0.06f);

        //エフェクトを非表示
        m_shotEffect.SetActive(false);
    }

    private IEnumerator HitEffect(Vector3 position)
    {
        //エフェクトの表示
        m_hitEffect.transform.position = position;
        m_hitEffect.SetActive(true);

        //少し待機
        yield return new WaitForSeconds(0.1f);

        //エフェクトを削除
        m_hitEffect.SetActive(false);
    }
}
