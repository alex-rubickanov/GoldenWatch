using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("---------PROPERTIES----------")]
    [SerializeField] protected int currentAmmo;
    [SerializeField] protected float shootingSpeed;

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
        inputHandler = GameObject.FindAnyObjectByType<InputHandler>();
        audioManager = GameObject.FindAnyObjectByType<AudioManagerScript>();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetAxis($"{inputHandler.GetPlayerRole}Fire") > 0)
        {
            print(inputHandler.GetPlayerRole);
            Shoot();
        }
    }
    public virtual void Shoot()
    {
        if(timer >= shootingSpeed && currentAmmo > 0)
        {
            timer = 0f; 
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawner.position, bulletSpawner.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawner.forward * bulletSpeed, ForceMode.Impulse);
            currentAmmo -= 1;
            ParticleSystem gunShotFX =  Instantiate(gunShotParticle, bulletSpawner.position, bulletSpawner.rotation);
            var main = gunShotFX.main;
            main.simulationSpeed = gunShotPlayBackSpeed;
            audioManager.PlayGunSound(this, volume);
            
        }
    }

    public bool HasAmmo()
    {
        if (currentAmmo <= 0) {
            return false;
        } else return true;
    }
}
