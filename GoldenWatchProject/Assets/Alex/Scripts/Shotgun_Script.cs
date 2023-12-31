using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shotgun_Script : Weapon
{
    [SerializeField] private Transform[] bulletSpawners;

    
    public override void Shoot()
    {
        Debug.Log("Xuy");
        if(gameObject.GetComponentInParent<ShootingSpeedX2>() != null) {
            if (timer >= shootingSpeedX2 && currentAmmo > 0) {
                timer = 0f;
                for (int i = 0; i < bulletSpawners.Length; i++) {
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawners[i].transform.position, bulletSpawners[i].transform.rotation);
                    bullet.GetComponent<BulletDamage>().SetDamage(damage);
                    bullet.GetComponent<Rigidbody>().AddForce(bulletSpawners[i].transform.forward * bulletSpeed, ForceMode.Impulse);
                }
                currentAmmo -= 1;
                ParticleSystem gunShotFX = Instantiate(gunShotParticle, bulletSpawner.position, bulletSpawner.rotation);
                var main = gunShotFX.main;
                main.simulationSpeed = gunShotPlayBackSpeed;
                audioManager.PlayGunSound(this, volume);
            }
        } else {
            if (timer >= shootingSpeed && currentAmmo > 0) {
                timer = 0f;
                for (int i = 0; i < bulletSpawners.Length; i++) {
                    GameObject bullet = Instantiate(bulletPrefab, bulletSpawners[i].transform.position, bulletSpawners[i].transform.rotation);
                    bullet.GetComponent<BulletDamage>().SetDamage(damage);
                    bullet.GetComponent<Rigidbody>().AddForce(bulletSpawners[i].transform.forward * bulletSpeed, ForceMode.Impulse);
                }
                currentAmmo -= 1;
                ParticleSystem gunShotFX = Instantiate(gunShotParticle, bulletSpawner.position, bulletSpawner.rotation);
                var main = gunShotFX.main;
                main.simulationSpeed = gunShotPlayBackSpeed;
                audioManager.PlayGunSound(this, volume);

            }
        }
        
    }
}
