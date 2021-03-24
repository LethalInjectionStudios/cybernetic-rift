using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private ThirdPersonCameraController _thirdPersonCameraController;
    private ThirdPersonMovementController _thirdPersonMovementController;

    private float _mouseX, _mouseY;
    private float _horizontalMovement, _verticalMovement;
    private Vector3 _playerMovement;
    public bool jumped = false;

    // Start is called before the first frame update
    void Start()
    {
        _thirdPersonCameraController = GetComponentInChildren<ThirdPersonCameraController>();
        _thirdPersonMovementController = GetComponent<ThirdPersonMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        _horizontalMovement = Input.GetAxisRaw("Horizontal");
        _verticalMovement = Input.GetAxisRaw("Vertical");
        _playerMovement = new Vector3(_horizontalMovement, 0f, _verticalMovement);

        if(Input.GetButtonDown("Jump"))
        {
            jumped = true;
            Debug.Log("Jump Pressed");
        }
        

        //Camera
        _mouseX += Input.GetAxis("Mouse X");
        _mouseY -= Input.GetAxis("Mouse Y");        
    }

    private void FixedUpdate() 
    {
        _thirdPersonMovementController.Movement(_playerMovement, jumped);
    }

    void LateUpdate() 
    {
        _thirdPersonCameraController.CamControl(_mouseX, _mouseY);
    }
}
