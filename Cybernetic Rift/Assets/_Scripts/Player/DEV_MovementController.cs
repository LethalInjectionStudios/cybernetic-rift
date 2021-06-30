using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEV_MovementController : MonoBehaviour
{
    private Vector3 _movement;
    private Vector3 _rotation;
    private Vector3 _camRotation;
    private Rigidbody _rigidbody;
    private GameObject _cameraTarget;
    private bool _jumped = false;
    private float _movementSpeed = 7.5f;
    private float _jumpForce = 5f;
    private float minRotation = -45f;
    private float maxRotation = 30f;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _cameraTarget = GameObject.FindGameObjectWithTag("CamTarget");
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical")).normalized;
        _rotation = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0);
        _camRotation = new Vector3(-Input.GetAxisRaw("Mouse Y"), 0, 0);

        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            _jumped = true;
        }
    }

    void FixedUpdate() 
    {
        transform.Translate(_movement * Time.fixedDeltaTime * _movementSpeed);
        transform.Rotate(_rotation);

        _cameraTarget.transform.Rotate(_camRotation);
        Vector3 currentRotation = _cameraTarget.transform.localEulerAngles;
        currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
        _cameraTarget.transform.localRotation = Quaternion.Euler(currentRotation);
        
        if (_jumped)
        {
            _rigidbody.velocity = Vector2.up * _jumpForce;
            _jumped = false;
        }
    }
}
