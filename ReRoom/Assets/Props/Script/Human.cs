using UnityEngine;

public class Human : Props
{
    [SerializeField] Animator m_animator;
    
    protected override void StartExecute()
    {
        //アニメーションを変更
        m_animator.SetTrigger("Anomaly");
    }
}