using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_virtualCamera;
    [SerializeField] InputActionProperty m_lookAction;
    [SerializeField] float m_sensitivity;

    private CinemachinePOV m_pov;

    private void Awake()
    {
        m_pov = m_virtualCamera.GetCinemachineComponent<CinemachinePOV>();
        m_sensitivity = 30.0f;
    }

    private void OnEnable()
    {
        m_lookAction.action.Enable();
    }

    private void OnDisable()
    {
        m_lookAction.action.Disable();
    }

    private void Update()
    {
        //設定画面を開いていれば回転不可
        if (GameSceneManager.Instance.IsPaused) return;

        //入力値を取得
        Vector2 lookInput = m_lookAction.action.ReadValue<Vector2>();

        //感度を考慮した回転
        if (lookInput.sqrMagnitude > 0.001f)
        {
            m_pov.m_HorizontalAxis.Value += lookInput.x * m_sensitivity * Time.deltaTime;
            m_pov.m_VerticalAxis.Value -= lookInput.y * m_sensitivity * Time.deltaTime;
        }
    }

    public void SetSensitivity(float value)
    {
        m_sensitivity = value;
    }
}
