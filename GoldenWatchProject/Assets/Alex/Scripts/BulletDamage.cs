using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void Awake()
    {

    }

    public float GetDamage()
    {
        return damage;
    }
}
