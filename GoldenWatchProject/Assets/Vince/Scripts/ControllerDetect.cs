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
        if (numOfPlayersReady > 1) {
            startText.SetActive(true);
            //Load scene
        }
    }

    private void DetectPlayerGamePads()
    {
        if (controllerNames[0] != null) {
            if (Input.GetButtonDown("P1_Submit")) {
                SetNumberOfPlayerReady(0);
                playerReady[0].SetActive(true);
                joinBtns[0].SetActive(false);

            }
        } else if (controllerNames[1] != null) {
            if (Input.GetButtonDown("P2_Submit")) {
                SetNumberOfPlayerReady(1);
                playerReady[1].SetActive(true);
                joinBtns[1].SetActive(false);
            }
        }
    }

    void SetNumberOfPlayerReady(int playerNum)
    {
        if (!playerReady[playerNum].activeSelf) {
            numOfPlayersReady++;
        }
    }
}
