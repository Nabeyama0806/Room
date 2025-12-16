using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject m_ui;
    [SerializeField] InputAction m_openAction;
    [SerializeField] InputAction m_closeAction;

    private void OnEnable()
    {
        m_openAction.Enable();
        m_closeAction.Enable();

        m_openAction.performed += OnOpenUI;
        m_closeAction.performed += OnCloseUI;
    }

    private void OnDisable()
    {
        m_openAction.performed -= OnOpenUI;
        m_closeAction.performed -= OnCloseUI;

        m_openAction.Disable();
        m_closeAction.Disable();
    }

    private void Start()
    {
        // 初期状態は非表示
        m_ui.SetActive(false);
    }

    private void OnOpenUI(InputAction.CallbackContext context)
    {
        ToggleUI(true);
    }

    private void OnCloseUI(InputAction.CallbackContext context)
    {
        ToggleUI(false);
    }

    public void OnClick()
    {
        ToggleUI(false);
    }

    private void ToggleUI(bool flag)
    {
        //UIの表示/非表示
        m_ui.SetActive(flag);

        //カーソル
        Cursor.visible = flag;
        Cursor.lockState = flag ? CursorLockMode.None : CursorLockMode.Locked;

        //表示中ならプレイヤーの操作を停止
        GameSceneManager.Instance.IsPaused = flag;
    }
}