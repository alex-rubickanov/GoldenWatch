using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 10f;
    InputHandler inputHandler;
    [SerializeField] Transform playerBody;
    Rigidbody rb;
    float y;
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

      

        Vector3 movement = new Vector3(xMovement, 0,yMovement);

        rb.velocity = movement * movementSpeed;

        print(rb.velocity.x + " " + rb.velocity.y);

        float rot = playerBody.transform.localEulerAngles.y;

         if (rot >= 90 && rot < 180)
        {
            y = -yMovement;
            print("back");
        }
    

        print(y);
    }

    private void IncreaseSpeed()
    {
        
    }
}
