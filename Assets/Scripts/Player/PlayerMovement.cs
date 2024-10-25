using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement: MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;

    [Header("Look")]
    [SerializeField] private Transform cameraContainer;
    [SerializeField] private float MinXLook;
    [SerializeField] private float MaxXLook;
    private float camCurXrot;
    [SerializeField] private float lookSensitivity;

    private Rigidbody _rigidbody;
    private PlayerController _playerController;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }


    private void Move()
    {
        Vector3 dir = transform.forward * _playerController.curMovementInput.y + transform.right * _playerController.curMovementInput.x;
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y;

        _rigidbody.velocity = dir;
    }

    private void CameraLook()
    {
        camCurXrot += _playerController.mouseDelta.y * lookSensitivity;
        camCurXrot = Mathf.Clamp(camCurXrot, MinXLook, MaxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXrot, 0, 0);

        transform.eulerAngles += new Vector3(0, _playerController.mouseDelta.x * lookSensitivity, 0);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up*jumpForce,ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.3f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.3f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.3f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.3f) +(transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.1f, groundLayer))
            {
                return true;
            }
        }

        return false;
    }
}