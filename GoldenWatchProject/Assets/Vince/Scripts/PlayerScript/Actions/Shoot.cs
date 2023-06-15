using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject bullet;
    [SerializeField] Transform bulletSpawnPoint;
    [SerializeField] float bulletSpeed = 100f;

    InputHandler inputHandler;

    private void Start()
    {
        inputHandler = GetComponent<InputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        if (Input.GetAxis($"{inputHandler.GetPlayerRole}Fire") > 0)
        {
            GameObject bulletObj = Instantiate(bullet, bulletSpawnPoint.position, Quaternion.identity);
            bulletObj.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }
}
