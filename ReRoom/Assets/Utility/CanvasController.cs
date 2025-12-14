using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject m_slider;
    [SerializeField] InputAction m_action;

    bool m_isOpen;

    private void OnEnable()
    {
        m_action.Enable();
        m_action.performed += OnToggleUI;
    }

    private void OnDisable()
    {
        m_action.performed -= OnToggleUI;
        m_action.Disable();
    }

    private void Start()
    {
        // 初期状態は非表示
        m_slider.SetActive(false);
        m_isOpen = false;
    }

    void OnToggleUI(InputAction.CallbackContext context)
    {
        //UIの表示/非表示
        m_isOpen = !m_isOpen;
        m_slider.SetActive(m_isOpen);

        //カーソル
        Cursor.lockState = m_isOpen ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = m_isOpen;

        //表示中はゲームを停止
        GameSceneManager.Instance.IsPaused = m_isOpen;
    }
}
