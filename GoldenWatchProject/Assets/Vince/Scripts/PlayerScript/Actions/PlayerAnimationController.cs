using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Movement movementScript;

    private const string VELOCITY_X = "VelX";
    private const string VELOCITY_Z = "VelZ";

    private Vector3 moveDirection = Vector3.zero;


    private void Start()
    {
        animator = GetComponent<Animator>();
        movementScript= GetComponentInParent<Movement>();
    }

    private void Update()
    {
        Animating(movementScript.GetLeftJoystickInput().x, movementScript.GetLeftJoystickInput().z);
    }

    void Animating(float h, float v)
    {
        moveDirection = new Vector3(h, 0, v);

        //if (moveDirection.magnitude > 1.0f) {
        //    moveDirection = moveDirection.normalized;
        //}

        moveDirection = transform.InverseTransformDirection(moveDirection);

        animator.SetFloat(VELOCITY_X, moveDirection.x);
        animator.SetFloat(VELOCITY_Z, moveDirection.z);
    }
}
