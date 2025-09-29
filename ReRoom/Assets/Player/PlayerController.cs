using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float m_moveSpeed;         //�ړ����x
    [SerializeField] float m_jumpPower;         //�W�����v��
    [SerializeField] AudioClip m_bulletShot;    //�ˌ���

    private CharacterController m_characterController;
    private PlayerInput m_playerInput;
    private Vector3 m_inputValue;   


    void Awake()
    {
        //�R���|�[�l���g�̎擾
        m_characterController = GetComponent<CharacterController>();
        m_playerInput = GetComponent<PlayerInput>();

        //�J�[�\���̔�\��
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnEnable()
    {
        //���͎��̃C�x���g��ݒ�
        m_playerInput.actions["Move"].performed += OnMove;
        m_playerInput.actions["Move"].canceled += OnMoveCancel;

        m_playerInput.actions["Jump"].performed += OnJump;

        m_playerInput.actions["Shot"].performed += OnShot;
    }

    private void OnDisable()
    {
        //�ݒ肵���C�x���g�̏��O
        m_playerInput.actions["Move"].performed -= OnMove;
        m_playerInput.actions["Move"].canceled -= OnMoveCancel;

        m_playerInput.actions["Jump"].performed -= OnJump;

        m_playerInput.actions["Shot"].performed -= OnShot;
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        //�ړ��ʂ̎擾
        Vector2 input = context.ReadValue<Vector2>();
        m_inputValue = new Vector3(input.x, m_inputValue.y, input.y);
    }

    private void OnMoveCancel(InputAction.CallbackContext context)
    {
        //�ړ��ʂ��Ȃ���
        m_inputValue = Vector3.zero;
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        //�ڒn���Ă���Ώ�����ɑ��x��^����
        if (!m_characterController.isGrounded) return;
        m_inputValue.y = m_jumpPower;
    }

    private void OnShot(InputAction.CallbackContext context)
    {
        //�ˌ����̍Đ�
        SoundManager.Play2D(m_bulletShot);

        RaycastHit hit; 
        Ray ray = new Ray(transform.position, Camera.main.transform.position);

        //�e���̐���
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {

        }
    }

    private void FixedUpdate()
    {
        //�ړ�
        Move();

        //���R����
        m_inputValue.y += Physics.gravity.y * Time.deltaTime;
    }

    private void Move()
    {
        //�J�����̌������l�������ړ���
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveVelocity = cameraForward * m_inputValue.z + Camera.main.transform.right * m_inputValue.x;
        moveVelocity = new Vector3(moveVelocity.x * m_moveSpeed, m_inputValue.y, moveVelocity.z * m_moveSpeed);

        //�ړ�
        m_characterController.Move(moveVelocity * Time.deltaTime);

        //�ړ����Ă���Ή�]������
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