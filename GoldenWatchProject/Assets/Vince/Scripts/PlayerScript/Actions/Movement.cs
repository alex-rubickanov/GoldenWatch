using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    float movementSpeedX2;
    InputHandler inputHandler;
    [SerializeField] Transform playerBody;
    Rigidbody rb;
    Vector3 movement;

    private void Awake()
    {
        inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        movementSpeedX2 = movementSpeed * 2;
    }

    void FixedUpdate()
    {
        if(inputHandler.GetPlayerNum() == InputHandler.PlayerRole.Player_KB) {
            MoveKB();
        } else {
            Move();
        }
    }

    private void Move()
    {
        float xMovement = Input.GetAxis(inputHandler.GetPlayerRole + "LS_Horizontal");
        float yMovement = Input.GetAxis(inputHandler.GetPlayerRole + "LS_Vertical");

        if (gameObject.GetComponent<MovementSpeedX2>() != null) {
            movement = new Vector3(xMovement, 0, yMovement) * movementSpeedX2;
        } else {
            movement = new Vector3(xMovement, 0, yMovement) * movementSpeed;
        }

        rb.velocity = movement;
    }

    private void MoveKB()
    {
        float xMovement = Input.GetAxis(inputHandler.GetPlayerRole + "LS_Horizontal");
        float yMovement = Input.GetAxis(inputHandler.GetPlayerRole + "LS_Vertical");

        
        movement = new Vector3(xMovement, 0, yMovement);
        
        if (gameObject.GetComponent<MovementSpeedX2>() != null) {
            rb.velocity = movement.normalized * movementSpeedX2;
        } else {
            rb.velocity = movement.normalized * movementSpeed;
        }
        
    }


    public Vector3 GetLeftJoystickInput()
    {   
        if(inputHandler.GetPlayerNum() == InputHandler.PlayerRole.Player_KB) {
            return rb.velocity;
        }else {
            return movement;
        }
        
    }

}
