using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoint : MonoBehaviour
{
    [SerializeField] private GameObject weapon;

    private void OnTriggerEnter(Collider other)
    {
        PlayerWeaponController playerWeaponController = other.GetComponent<PlayerWeaponController>();
        if (playerWeaponController != null) {
            playerWeaponController.GiveWeapon(weapon);
        }
    }
}
