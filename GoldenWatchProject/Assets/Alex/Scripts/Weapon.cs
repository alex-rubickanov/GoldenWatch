using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("---------PROPERTIES----------")]
    [SerializeField] private int maxAmmo;
    [SerializeField] protected int currentAmmo;
    [SerializeField] protected float damage;
    [SerializeField] protected float shootingSpeed;
    protected float shootingSpeedX2;

    [Header("---------BULLET----------")]
    [SerializeField] protected GameObject bulletPrefab;
    [SerializeField] protected float bulletSpeed;
    [SerializeField] protected Transform bulletSpawner;

    [Header("---------FX AND SOUNDS----------")]
    [SerializeField] protected float volume;
    [SerializeField] protected ParticleSystem gunShotParticle;
    [SerializeField] protected float gunShotPlayBackSpeed;
    protected AudioManagerScript audioManager;
    [SerializeField] public AudioClip gunShotSound;
    protected float timer = 1f;

    protected InputHandler inputHandler;

    private void Awake()
    {
        inputHandler = gameObject.GetComponentInParent<InputHandler>();
        audioManager = GameObject.FindAnyObjectByType<AudioManagerScript>();

        currentAmmo = maxAmmo;
        shootingSpeedX2 = shootingSpeed / 2;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetAxis($"{inputHandler.GetPlayerRole}Fire") > 0)
        {
            Shoot();
        }

        
    }
    public virtual void Shoot()
    {
        if(gameObject.GetComponentInParent<ShootingSpeedX2>() != null) {
            if (timer >= shootingSpeedX2 && currentAmmo > 0) {
                timer = 0f;
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
                bullet.GetComponent<BulletDamage>().SetDamage(damage);
                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawner.forward * bulletSpeed, ForceMode.Impulse);
                currentAmmo -= 1;
                ParticleSystem gunShotFX = Instantiate(gunShotParticle, bulletSpawner.position, bulletSpawner.rotation);
                var main = gunShotFX.main;
                main.simulationSpeed = gunShotPlayBackSpeed;
                audioManager.PlayGunSound(this, volume);
            }
        } else {
            if (timer >= shootingSpeed && currentAmmo > 0) {
                timer = 0f;
                GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
                bullet.GetComponent<BulletDamage>().SetDamage(damage);
                bullet.GetComponent<Rigidbody>().AddForce(bulletSpawner.forward * bulletSpeed, ForceMode.Impulse);
                currentAmmo -= 1;
                ParticleSystem gunShotFX = Instantiate(gunShotParticle, bulletSpawner.position, bulletSpawner.rotation);
                var main = gunShotFX.main;
                main.simulationSpeed = gunShotPlayBackSpeed;
                audioManager.PlayGunSound(this, volume);

            }
        }
        
    }

    public bool HasAmmo()
    {
        if (currentAmmo <= 0) {
            return false;
        } else return true;
    }

    public void SetShootingSpeed(float newSpeed)
    {
        shootingSpeed = newSpeed;
    }

    public void RefreshAmmo()
    {
        currentAmmo = maxAmmo;
    }
}
