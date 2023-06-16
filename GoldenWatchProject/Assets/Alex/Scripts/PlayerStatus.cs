using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    private RagdollEnabler ragdoll;
    [SerializeField] ParticleSystem bloodVFX;

    [SerializeField] private float health;

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
            Instantiate(bloodVFX, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1.5f,gameObject.transform.position.z), Quaternion.identity);
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

    public void Heal(float heal)
    {
        health += heal;
    }
}
