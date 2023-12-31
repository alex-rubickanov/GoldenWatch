using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4_Script : Weapon
{
    [Header("----------BURST PROPERTIES----------")]
    [SerializeField] private float burstSpeed;
    
    public override void Shoot()
    {
        if (gameObject.GetComponentInParent<ShootingSpeedX2>() != null) {
            if (timer >= shootingSpeedX2 && currentAmmo > 0) {
                StartCoroutine(BurstFire());
            }
        } else {
            if (timer >= shootingSpeed && currentAmmo > 0) {
                StartCoroutine(BurstFire());
            }
        }
        
    }
    
    private IEnumerator BurstFire()
    {
        timer = 0f;

        for(int i = 0; i < 3; i++) {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            bullet.GetComponent<BulletDamage>().SetDamage(damage);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawner.forward * bulletSpeed, ForceMode.Impulse);
            
            ParticleSystem gunShotFX = Instantiate(gunShotParticle, bulletSpawner.position, bulletSpawner.rotation);
            var main = gunShotFX.main;
            main.simulationSpeed = gunShotPlayBackSpeed;
            audioManager.PlayGunSound(this, volume);
            currentAmmo -= 1;
            yield return new WaitForSeconds(burstSpeed);
        }
       
    }
}
