using UnityEngine;
using UnityEngine.InputSystem;

public class TitleSceneController : MonoBehaviour
{
    private const float StayTime = 1.5f; //入力受付するまでの待機時間

    [SerializeField] private InputAction startAction;

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
        startAction.performed += OnStart;
        startAction.Enable();
    }

    private void OnDisable()
    {
        startAction.performed -= OnStart;
        startAction.Disable();
    }

    private void OnStart(InputAction.CallbackContext context)
    {
        //入力受付可能でなければ処理しない
        if (!m_isInputEnabled) return;

        SceneController.Transition(SceneType.Title, SceneType.Game);
    }
}
