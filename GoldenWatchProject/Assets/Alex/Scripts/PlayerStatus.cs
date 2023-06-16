using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private float health;
    private RagdollEnabler ragdoll;

    private void Awake()
    {
        ragdoll = gameObject.GetComponentInChildren<RagdollEnabler>();    
    }

    private void Update()
    {
        CheckDeath();
    }
    private void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet") {
            TakeDamage(other.gameObject.GetComponent<BulletDamage>().GetDamage());
            Destroy(other.gameObject);
        }
    }

    private void CheckDeath()
    {
        if(health <= 0) {
            ragdoll.EnableRagdoll();
        }
    }
}
