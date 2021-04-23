using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Camera _camera;
    [SerializeField] private Vector3 _movement;
    [SerializeField] Vector3 _rotation;
    [SerializeField] private Vector3 _movementDirection;
    private bool _jumped = false;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;


    [SerializeField] private float _movementSpeed = 15f;
    [SerializeField] private float _jumpForce = 5f;

    void Awake() 
    {
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
        _rotation = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0);

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
            //_rigidbody.rotation = Quaternion.Euler(0f, _angle, 0f);
            _movementDirection = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward * _movementSpeed;
            transform.position += _movementDirection * Time.fixedDeltaTime * _movementSpeed;
            //_rigidbody.velocity = _movementDirection * Time.fixedDeltaTime * _movementSpeed;
        }

        if (_jumped)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _jumped = false;
        }
    }
}


  