using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private const float RayLength = 2.5f;

    [SerializeField] float m_moveSpeed;         //移動速度
    [SerializeField] float m_jumpPower;         //ジャンプ力
    [SerializeField] CinemachineVirtualCamera m_virtualCamera; //カメラ
    [SerializeField] GameObject m_revolver;     //銃のモデル
    [SerializeField] GameObject m_canOpenUI;

    private CharacterController m_characterController;
    private PlayerInput m_playerInput;
    private Vector3 m_inputValue;
    private bool m_canOpen;

    void Awake()
    {
        //カーソルを消して中央に固定
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        //コンポーネントの取得
        m_characterController = GetComponent<CharacterController>();
        m_playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        //移動
        Move();

        //重力
        m_inputValue.y += Physics.gravity.y * Time.deltaTime;
    }

    private void Update()
    {
        //手の届く範囲にドアがあるか判定
        DoorController door = null;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit, RayLength))
        {
            //ドアがあったら開閉可能にする
            if (hit.transform.gameObject.CompareTag("Door"))
            {
                m_canOpenUI.SetActive(true);
                door = hit.transform.gameObject.GetComponent<DoorController>();
                door.CanOpen = true;
            }
        }
        else
        {
            //手が届かない範囲にある場合はUIを非表示にする
            m_canOpenUI.SetActive(false);

            //前に触れていたドアの開閉を不可にする
            if (door != null)
            {
                door.CanOpen = false;
                door = null;
            }
        }
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
        //銃を撃つ
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out var hit))
        {
            //壁や床は無視する
            if (!hit.transform.gameObject.CompareTag("Props")) return;

            //弾の発射
            m_revolver.GetComponent<RevolverController>().Shot(hit.point);

            //当たったオブジェクトの処理
            hit.transform.gameObject.GetComponent<Props>().Hit();
        }
    }

    private void Move()
    {
        //カメラの向きに合わせて移動方向を決定
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 moveVelocity = cameraForward * m_inputValue.z + Camera.main.transform.right * m_inputValue.x;
        moveVelocity = new Vector3(moveVelocity.x * m_moveSpeed, m_inputValue.y, moveVelocity.z * m_moveSpeed);

        //移動
        m_characterController.Move(moveVelocity * Time.deltaTime);

        //カメラの回転量を取得
        float yaw = m_virtualCamera.GetCinemachineComponent<CinemachinePOV>().m_HorizontalAxis.Value;

        //プレイヤーを左右に回転
        transform.rotation = Quaternion.Euler(0, yaw, 0);
    }
}