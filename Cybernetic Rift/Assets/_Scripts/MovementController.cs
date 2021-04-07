using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementController : MonoBehaviour
{
    private CharacterController _characterController;
    private Camera _camera;
    private float _movementX, _movementZ;
    [SerializeField] private float _movementSpeed = 6f;
    private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity;
    private Vector3 _movementDirection;

    void Awake() 
    {
        _characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        _movementX = Input.GetAxisRaw("Horizontal");
        _movementZ = Input.GetAxisRaw("Vertical");

        Vector3 _Direction = new Vector3(_movementX, 0f, _movementZ).normalized;

        if(_Direction.magnitude >= 0.1f)
        {
            float _targetAngle = Mathf.Atan2(_Direction.x, _Direction.z) * Mathf.Rad2Deg + _camera.transform.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            _movementDirection = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward * _movementSpeed;
            _characterController.Move(_movementDirection.normalized * _movementSpeed * Time.deltaTime);
        }
    }
}



  