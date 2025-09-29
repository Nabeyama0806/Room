using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera m_virtualCamera;
    [SerializeField] InputActionProperty m_lookAction;
    [SerializeField] float m_sensitivity = 200f;

    private CinemachinePOV pov;

    private void Awake()
    {
        pov = m_virtualCamera.GetCinemachineComponent<CinemachinePOV>();
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
        Vector2 lookInput = m_lookAction.action.ReadValue<Vector2>();

        //“ü—Í‚ðPOV‚É“n‚·
        if (lookInput.sqrMagnitude < 0.001f) return;
        pov.m_HorizontalAxis.Value += lookInput.x * m_sensitivity * Time.deltaTime;
        pov.m_VerticalAxis.Value -= lookInput.y * m_sensitivity * Time.deltaTime; 
    }
}
