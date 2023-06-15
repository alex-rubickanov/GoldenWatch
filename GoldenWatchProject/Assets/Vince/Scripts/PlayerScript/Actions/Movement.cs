using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    InputHandler inputHandler;
    Rigidbody rb;
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

        Vector3 movement = new Vector3(xMovement, 0, yMovement);
        movement.Normalize();

        rb.velocity = movement * movementSpeed;
    }
}
