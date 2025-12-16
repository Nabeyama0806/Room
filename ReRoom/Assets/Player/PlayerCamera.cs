using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCamera : MonoBehaviour
{
    private const float ReferenceBaseSensitivity = 60.0f;
    
    [SerializeField] CinemachineVirtualCamera m_virtualCamera;
    [SerializeField] InputActionProperty m_lookAction;
    [SerializeField] float m_baseSensitivity;

    private float m_referenceMouseSensitivity;
    private float m_referenceGamepadSensitivity;
    private CinemachinePOV m_pov;

    private void Awake()
    {
        m_pov = m_virtualCamera.GetCinemachineComponent<CinemachinePOV>();

        m_referenceMouseSensitivity = 100.0f;
        m_referenceGamepadSensitivity = 400.0f;
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

    private float GetDeviceSensitivity()
    {
        //入力デバイスの取得
        var control = m_lookAction.action.activeControl;

        //基本感度
        float scale = m_baseSensitivity / ReferenceBaseSensitivity;
        float baseDeviceSensitivity = 0;

        if (control != null)
        {
            //マウス感度
            if (control.device is Mouse) baseDeviceSensitivity = m_referenceMouseSensitivity;

            //ゲームパッド感度
            if (control.device is Gamepad) baseDeviceSensitivity = m_referenceGamepadSensitivity;
        }

        return baseDeviceSensitivity * scale;

    }

    // UI用
    public void SetBaseSensitivity(float value)
    {
        m_baseSensitivity = value;
    }
}
