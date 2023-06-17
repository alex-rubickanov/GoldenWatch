using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    private RagdollEnabler ragdoll;
    [SerializeField] ParticleSystem bloodVFX;
    [SerializeField] Transform spawnPoint;
    [SerializeField] private float health;
    private PlayerManager playerManager;
    private bool once = true;
    [SerializeField] Slider healthSlider;
    [SerializeField] GameObject attributes;

    private void Awake()
    {
        playerManager = GetComponentInParent<PlayerManager>();
        ragdoll = gameObject.GetComponentInChildren<RagdollEnabler>();
        healthSlider.maxValue = health;
    }

    private void Update()
    {
        if (health > 200) {
            health = 200;
        }
        CheckDeath();
        healthSlider.value = health;
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
            attributes.SetActive(false);
            ragdoll.EnableRagdoll();
            gameObject.GetComponent<Movement>().enabled = false;
            gameObject.GetComponent<Rotation>().enabled = false;
            if(once) {
                playerManager.StartRespawn();
                once = false;
            }
            
        }
    }

    public void Heal(float heal)
    {
        health += heal;
    }

    public float GetHealth()
    {
        return health;
    }
}
