using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    private CharacterController _characterController;
    private Rigidbody _rigidbody;
    private Camera _camera;
    private float _movementX, _movementZ;
    private Vector3 _movement;
    private bool _jumped = false;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    private Vector3 _movementDirection;
    private Vector3 velocity;

    [SerializeField] private float _movementSpeed = 6f;
    [SerializeField] private float _gravity = -9.81f;
    [SerializeField] private float _jumpHeight = 3f;
    private float _jumpForce = 5f;

    void Awake() 
    {
        //_characterController = GetComponent<CharacterController>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        _camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _jumped = true;
        }
    }

    void FixedUpdate() 
    {
        if(_movement != Vector3.zero)
        {
            float _targetAngle = Mathf.Atan2(_movement.x, _movement.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            _movementDirection = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward * _movementSpeed;
            transform.position += _movementDirection * Time.fixedDeltaTime * _movementSpeed;
        }


        if (_jumped)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _jumped = false;
            //_audioController.PlayJump();
        }
    }
}



  