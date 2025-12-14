using UnityEngine;
using UnityEngine.InputSystem;

public class CanvasController : MonoBehaviour
{
    [SerializeField] GameObject m_ui;
    [SerializeField] InputAction m_action;

    private void OnEnable()
    {
        m_action.Enable();
        m_action.performed += OnOpenUI;
    }

    private void OnDisable()
    {
        m_action.performed -= OnOpenUI;
        m_action.Disable();
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

    public void OnCloseUI()
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