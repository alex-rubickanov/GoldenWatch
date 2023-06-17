using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSpeedX2 : MonoBehaviour
{
    private float duration = 5f;

    private void Update()
    {
        if(gameObject.GetComponentInParent<Movement>() != null) {
            Destroy(this, duration);
        }
    }
}
