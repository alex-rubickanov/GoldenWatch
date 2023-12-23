using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationControllerKB : MonoBehaviour
{
    private Animator animator;
    private MovementKB movementScript;

    private const string VELOCITY_X = "VelX";
    private const string VELOCITY_Z = "VelZ";
    private const string HAS_WEAPON = "HasWeapon";

    private Vector3 moveDirection = Vector3.zero;

    private PlayerWeaponController playerWeaponController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        movementScript = GetComponentInParent<MovementKB>();
        playerWeaponController = GetComponentInParent<PlayerWeaponController>();
    }

    private void Update()
    {
        Animating(movementScript.GetLeftJoystickInput().x, movementScript.GetLeftJoystickInput().z);
        if (playerWeaponController.HasWeapon()) {
            animator.SetBool(HAS_WEAPON, true);
        } else {
            animator.SetBool(HAS_WEAPON, false);
        }
    }

    void Animating(float h, float v)
    {
        moveDirection = new Vector3(h*5, 0, v*5);

        //if (moveDirection.magnitude > 1.0f) {
        //    moveDirection = moveDirection.normalized;
        //}

        moveDirection = transform.InverseTransformDirection(moveDirection);

        animator.SetFloat(VELOCITY_X, moveDirection.x);
        animator.SetFloat(VELOCITY_Z, moveDirection.z);
    }
}
