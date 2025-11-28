using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] bool m_canOpen;

    private const float RayLength = 3.5f;
    private readonly Vector3 RayOffset = new Vector3(0, 1, 0);

    private Animator m_animator;
    private bool m_isOpen;

    public bool CanOpen 
    { 
        set { m_canOpen = value; } 
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + RayOffset, transform.forward * RayLength, Color.yellow);

        //ドアが開けられる状態でなければ何もしない
        if (!m_canOpen) return;

        //手の届く範囲にプレイヤーがいればドアを開ける
        if (Physics.Raycast(transform.position + RayOffset, transform.forward, out var hit, RayLength))
        {
            if (hit.transform.gameObject.CompareTag("Player"))
            {
                m_isOpen = true;
            }
        }
        else 
        {
            m_isOpen = false;
        }

        //アニメーションの更新
        m_animator.SetBool("Open", m_isOpen);
    }
}
