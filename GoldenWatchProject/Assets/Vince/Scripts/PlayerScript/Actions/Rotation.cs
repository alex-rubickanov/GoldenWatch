using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Rotation : MonoBehaviour
{
    [SerializeField] float smoothRotationSpeed = 5f;
    [SerializeField] Transform anchor;
    [SerializeField] Transform targetSight;
    [SerializeField] Transform playerBody;
    public float rot;
    InputHandler inputHandler;

    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
         rot = playerBody.transform.localEulerAngles.y;
        Rotate();
    }

    private void Rotate()
    {
        float xRotation = Input.GetAxis($"{inputHandler.GetPlayerRole}RS_Horizontal");
        float yRotation = Input.GetAxis($"{inputHandler.GetPlayerRole}RS_Vertical");

        Vector3 faceDirection = new Vector3(xRotation, 0, yRotation);
        faceDirection.Normalize();

        float currentRotationY = anchor.transform.localEulerAngles.y;
        if (currentRotationY > 180f)
        {
            currentRotationY -= 360f;
        }
        if (faceDirection != Vector3.zero)
        {
            anchor.transform.forward = faceDirection;
        }

        if (currentRotationY > 90f || currentRotationY < -90f)
        {
            if (yRotation != 0 && xRotation != 0)
            {
                Vector3 directionToTarget = targetSight.position - playerBody.position;
                directionToTarget.y = 0; // Set Y axis to 0
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                playerBody.rotation = Quaternion.Slerp(playerBody.rotation, targetRotation, smoothRotationSpeed * Time.deltaTime);
            }
        }
    }
}
