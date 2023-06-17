using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private float damage;

    public float GetDamage()
    {
        return damage;
    }

    public void SetDamage(float damage)
    {
        this.damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Movement>() == null && other.gameObject.tag != "Bullet" && other.gameObject.tag != "PickUp") {
            Destroy(gameObject);
        }
    }
}
