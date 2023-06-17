using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetControllers : MonoBehaviour
{
    [SerializeField] public List<string> controllerNames;

    // Update is called once per frame
    void Update()
    {
        controllerNames = new List<string>(Input.GetJoystickNames());
    }
}
