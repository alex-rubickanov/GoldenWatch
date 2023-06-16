using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    InputHandler inputHandler;
    [SerializeField] Transform playerBody;
    Rigidbody rb;
    Vector3 movement;

    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        //float xMovement = Input.GetAxis($"{inputHandler.GetPlayerRole}LS_Horizontal");
        //float yMovement = Input.GetAxis($"{inputHandler.GetPlayerRole}LS_Vertical");

        float xMovement = Input.GetAxis(inputHandler.GetPlayerRole + "LS_Horizontal");
        float yMovement = Input.GetAxis(inputHandler.GetPlayerRole + "LS_Vertical");

        movement = new Vector3(xMovement, 0, yMovement) * movementSpeed;
        
        rb.velocity = movement;
    }


    public Vector3 GetLeftJoystickInput()
    {   
        return movement;
    }

}
