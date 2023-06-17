using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenWatch : MonoBehaviour
{
    Transform playerPos;
    
    private void Update()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            transform.SetParent(other.gameObject.transform);
            transform.position = other.transform.Find("WatchPos").position;
        }
    }
}
