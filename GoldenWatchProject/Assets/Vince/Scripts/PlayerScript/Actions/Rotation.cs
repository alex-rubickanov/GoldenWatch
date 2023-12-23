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
    InputHandler inputHandler;
    [SerializeField] private LayerMask groundMask;
    private Camera aimCamera;
    private Vector2 aim;

    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();
        //aimCamera = GameObject.FindGameObjectWithTag("AimCamera").GetComponent<Camera>();
        aimCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(inputHandler.GetPlayerNum() == InputHandler.PlayerRole.Player_KB) {
            Aim();
        } else {
            Rotate();
        }
    }

    private void Rotate()
    {
        float xRotation = Input.GetAxis(inputHandler.GetPlayerRole + "RS_Horizontal");
        float yRotation = Input.GetAxis(inputHandler.GetPlayerRole + "RS_Vertical");

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

    private void RotateKB()
    {
        Vector3 mousePos = GetMousePosition().position;

        Vector3 faceDirection = new Vector3(mousePos.x, 0, mousePos.z);
        //faceDirection.Normalize();

        float currentRotationY = anchor.transform.localEulerAngles.y;
        if (currentRotationY > 180f) {
            currentRotationY -= 360f;
        }
        if (faceDirection != Vector3.zero) {
            anchor.transform.forward = faceDirection;
        }

        if (currentRotationY > 90f || currentRotationY < -90f) {
            if (mousePos.x != 0 && mousePos.y != 0) {
                Vector3 directionToTarget = targetSight.position - playerBody.position;
                directionToTarget.y = 0; // Set Y axis to 0
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                playerBody.rotation = Quaternion.Slerp(playerBody.rotation, targetRotation, smoothRotationSpeed * Time.deltaTime);
            }
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = aimCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask)) {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        } else {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success) {
            // Calculate the direction
            var direction = position - playerBody.transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            playerBody.transform.forward = direction;
            Debug.Log(direction);
        }
    }

    private void TestRotation()
    {
        aim = Input.mousePosition;
        Ray ray = aimCamera.ScreenPointToRay(aim);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if(groundPlane.Raycast(ray, out rayDistance)) {
            Vector3 point = ray.GetPoint(rayDistance);
            playerBody.LookAt(point);
        }
    }

    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, 0, lookPoint.z);
        playerBody.transform.LookAt(heightCorrectedPoint);
    }
}
