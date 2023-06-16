using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDetect : MonoBehaviour
{
    [SerializeField] string[] controllerNames;
    [SerializeField] GameObject[] playerReady;
    [SerializeField] GameObject[] joinBtns;
    [SerializeField] GameObject startText;
    [SerializeField] float numOfPlayersReady;
    void Start()
    {
        controllerNames = Input.GetJoystickNames();
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayerGamePads();
        StartGame();
    }

    private void StartGame()
    {
        if(numOfPlayersReady > 1)
        {
            startText.SetActive(true);
            //Load scene
        }
    }

    private void DetectPlayerGamePads()
    {
        if (controllerNames[1] != null)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                playerReady[0].SetActive(true);
                joinBtns[0].SetActive(false);
            }
        }

        if (controllerNames[2] != null)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                playerReady[1].SetActive(true);
                joinBtns[1].SetActive(false);
            }
        }
    }
}
