using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSceneController : MonoBehaviour
{
    private const float StayTime = 1.5f; //入力受付するまでの待機時間

    [SerializeField] private InputAction m_startAction;

    private float m_timer;          //経過時間
    private bool m_isInputEnabled;  //入力受付可能フラグ

    private void Start()
    {
        m_timer = 0f;
        m_isInputEnabled = false;
    }

    private void Update()
    {
        if (!m_isInputEnabled)
        {
            m_timer += Time.deltaTime;
            if (m_timer >= StayTime)
            {
                m_isInputEnabled = true;
            }
        }
    }

    private void OnEnable()
    {
        m_startAction.performed += OnStart;
        m_startAction.Enable();
    }

    private void OnDisable()
    {
        m_startAction.performed -= OnStart;
        m_startAction.Disable();
    }

    private void OnStart(InputAction.CallbackContext context)
    {
        //入力受付可能でなければ処理しない
        if (!m_isInputEnabled) return;

        //カーソルを消して中央に固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //シーン遷移
        SceneController.Transition(SceneType.Title, SceneType.Game);
    }
}
