using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{
    [SerializeField] float healAmount;
    enum TypeOfPowerUp 
    { 
        Heal,
        MovementSpeedX2,
        ShootingSpeedX2,
        RefreshAmmo
    }

    [SerializeField] TypeOfPowerUp powerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Movement>() != null) {
            switch(powerUp) {
                case TypeOfPowerUp.Heal:
                    other.gameObject.GetComponent<PlayerStatus>().Heal(healAmount);
                    break;
                case TypeOfPowerUp.MovementSpeedX2:
                    if(other.gameObject.GetComponent<MovementSpeedX2>() == null) {
                        other.gameObject.AddComponent<MovementSpeedX2>();
                    }
                    break;
                case TypeOfPowerUp.ShootingSpeedX2:
                    if(other.gameObject.GetComponent<ShootingSpeedX2>() == null) {
                        other.gameObject.AddComponent<ShootingSpeedX2>();
                    }
                    break;
                case TypeOfPowerUp.RefreshAmmo:
                    if(other.gameObject.GetComponent<PlayerWeaponController>().GetCurrentWeapon() == null) {
                        if(other.gameObject.GetComponent<PlayerWeaponController>().GetOldWeapon() != null) {
                            other.gameObject.GetComponent<PlayerWeaponController>().RefreshOldWeapon();
                        }
                    }
                    if(other.gameObject.GetComponent<PlayerWeaponController>().GetCurrentWeapon() != null) {
                        other.gameObject.GetComponentInChildren<Weapon>().RefreshAmmo();
                    }
                    
                    break;
            }
            Destroy(gameObject);
        }
    }
}
