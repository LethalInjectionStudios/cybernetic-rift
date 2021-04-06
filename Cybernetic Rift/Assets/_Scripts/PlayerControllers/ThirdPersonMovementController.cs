using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonMovementController : MonoBehaviour
{
    private float _speed = 10;
    private float _jumpForce = 7;
    private Rigidbody _rigidBody;

    private void Awake() 
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    public void Movement(Vector3 playerMovement, bool jumped)
    {
        playerMovement = playerMovement.normalized * _speed * Time.deltaTime;

        transform.Translate(playerMovement, Space.Self);

        if(jumped)
        {
            _rigidBody.velocity = Vector2.up * _jumpForce;
            GetComponent<PlayerInputController>().jumped = false;
        } 
    }
}
