﻿using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private LayerMask groundLayer;

    [Header("Look")]
    [SerializeField] private Transform cameraContainer;
    [SerializeField] private float MinXLook;
    [SerializeField] private float MaxXLook;
    private float camCurXrot;
    [SerializeField] private float lookSensitivity;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int maxJumpTime;
    private int jumpTime;

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
        if (context.phase == InputActionPhase.Started && jumpTime != 0)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            jumpTime--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpTime = maxJumpTime;
        }
    }
}