using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int currentAmmo;
    [SerializeField] private float damage;
    [SerializeField] private float shootingSpeed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform bulletSpawner;
    private InputHandler inputHandler;
    float timer = 1f;


    private void Start()
    {
        inputHandler = GameObject.FindAnyObjectByType<InputHandler>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(Input.GetAxis($"{inputHandler.GetPlayerRole}Fire") > 0)
        {
            Shoot();
        }
    }
    public virtual void Shoot()
    {
        if(timer >= shootingSpeed)
        {
            timer = 0f; 
            Debug.Log("Shooting");
            Instantiate(bulletPrefab, bulletSpawner.position, Quaternion.identity);
        }
    }
        

    public virtual void Reload()
    {

    }

}
