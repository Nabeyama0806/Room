using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_virtualCamera;
    [SerializeField] InputActionProperty m_lookAction;
    [SerializeField] float m_baseSensitivity = 10f;

    private float m_referenceBaseSensitivity = 50f;
    private float m_referenceMouseSensitivity = 10f;
    private float m_referenceGamepadSensitivity = 80f;
    private CinemachinePOV m_pov;

    private void Awake()
    {
        m_pov = m_virtualCamera.GetCinemachineComponent<CinemachinePOV>();
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
        //設定画面を開いていれば操作不可
        if (GameSceneManager.Instance.IsPaused) return;

        //入力値を取得
        Vector2 lookInput = m_lookAction.action.ReadValue<Vector2>();

        //回転
        if (lookInput.sqrMagnitude > 0.001f)
        {
            float sensitivity = GetDeviceSensitivity();
            m_pov.m_HorizontalAxis.Value += lookInput.x * sensitivity * Time.deltaTime;
            m_pov.m_VerticalAxis.Value -= lookInput.y * sensitivity * Time.deltaTime;
        }        
    }

    float GetDeviceSensitivity()
    {
        //入力デバイスの取得
        var control = m_lookAction.action.activeControl;

        //基本感度
        float scale = m_baseSensitivity / m_referenceBaseSensitivity;
        float baseDeviceSensitivity = m_referenceMouseSensitivity;

        //マウス
        if (control.device is Mouse) baseDeviceSensitivity = m_referenceMouseSensitivity;

        //ゲームパッド
        if (control.device is Gamepad) baseDeviceSensitivity = m_referenceGamepadSensitivity;

        return baseDeviceSensitivity * scale;
    }

    // UI用
    public void SetBaseSensitivity(float value)
    {
        m_baseSensitivity = value;
    }
}
