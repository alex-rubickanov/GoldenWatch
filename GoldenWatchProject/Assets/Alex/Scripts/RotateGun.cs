using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * 30f, 0);
    }
}
