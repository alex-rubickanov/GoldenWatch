using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoint : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    private AudioManagerScript audioManager;

    private void Awake()
    {
        audioManager = FindAnyObjectByType<AudioManagerScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerWeaponController playerWeaponController = other.GetComponent<PlayerWeaponController>();
        if (playerWeaponController != null) {
            if(playerWeaponController.GetCurrentWeapon() == null) {
                playerWeaponController.GiveWeapon(weapon);
                audioManager.PowerUpPickUp();
                Destroy(gameObject);
            }
        }
    }
}
