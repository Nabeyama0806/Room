using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;         //移動速度
    [SerializeField] float m_jumpPower;         //ジャンプ力
    [SerializeField] AudioClip m_bulletShot;    //射撃音

    private CharacterController m_characterController;
    private PlayerInput m_playerInput;
    private Vector3 m_inputValue;   


    void Awake()
    {
        //カーソルを消して中央に固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        m_characterController = GetComponent<CharacterController>();
        m_playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        m_playerInput.actions["Move"].performed += OnMove;
        m_playerInput.actions["Move"].canceled += OnMoveCancel;

        m_playerInput.actions["Jump"].performed += OnJump;

        m_playerInput.actions["Shot"].performed += OnShot;
    }

    private void OnDisable()
    {
        m_playerInput.actions["Move"].performed -= OnMove;
        m_playerInput.actions["Move"].canceled -= OnMoveCancel;

        m_playerInput.actions["Jump"].performed -= OnJump;

        m_playerInput.actions["Shot"].performed -= OnShot;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        m_inputValue = new Vector3(input.x, m_inputValue.y, input.y);
    }

    private void OnMoveCancel(InputAction.CallbackContext context)
    {
        m_inputValue = Vector3.zero;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!m_characterController.isGrounded) return;
        m_inputValue.y = m_jumpPower;
    }

    private void OnShot(InputAction.CallbackContext context)
    {
        SoundManager.Play2D(m_bulletShot);

        //カメラの中央からRayを飛ばす
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit))
        {
            Debug.Log(hit.transform.gameObject.name.ToString());
        }
    }

    private void FixedUpdate()
    {
        Move();

        m_inputValue.y += Physics.gravity.y * Time.deltaTime;
    }

    private void Move()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveVelocity = cameraForward * m_inputValue.z + Camera.main.transform.right * m_inputValue.x;
        moveVelocity = new Vector3(moveVelocity.x * m_moveSpeed, m_inputValue.y, moveVelocity.z * m_moveSpeed);

        m_characterController.Move(moveVelocity * Time.deltaTime);

        Vector3 move = new Vector3(m_inputValue.x, 0, m_inputValue.z);
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(move.normalized),
                0.2f
            );
        }
    }
}