using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    private Animator m_animator;
    private bool m_canOpen;

    public bool CanOpen
    {
        set { m_canOpen = value; }
    }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_canOpen = false;
    }

    public void OnDoorOpen(InputAction.CallbackContext context)
    {
        //開閉ボタンが押されたらドアを開ける
        if (context.performed && m_canOpen)
        {
            m_animator.SetTrigger("Open");
        }
    }
}
