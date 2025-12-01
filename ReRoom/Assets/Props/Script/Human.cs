using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : AnomalyProps
{
    [SerializeField] Animator m_animator;

    public override void StartExecute()
    {
        //アニメーションを変更
        m_animator.SetTrigger("Anomaly");
    }
}
