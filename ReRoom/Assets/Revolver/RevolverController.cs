using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevolverController : MonoBehaviour
{
    [SerializeField] AudioClip m_shotSound;
    [SerializeField] GameObject m_effect;

    public void Shot()
    {
        //効果音の再生
        SoundManager.Play2D(m_shotSound);

        //エフェクトの再生
        StartCoroutine(ShotEffect());
    }

    private IEnumerator ShotEffect()
    {
        //エフェクトを表示
        m_effect.SetActive(true);

        //少し待機
        yield return new WaitForSeconds(0.06f);

        //エフェクトを非表示
        m_effect.SetActive(false);
    }
}
