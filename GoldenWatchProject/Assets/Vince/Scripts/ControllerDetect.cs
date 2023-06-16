using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerDetect : MonoBehaviour
{
    [SerializeField] List<string> controllerNames;
    [SerializeField] GameObject[] playerReady;
    [SerializeField] GameObject[] joinBtns;
    [SerializeField] GameObject startText;
    [SerializeField] GameObject mainMenu;
    int numOfPlayersReady;

    void Update()
    {
        controllerNames = new List<string>(Input.GetJoystickNames());
        RemoveEmptyControllerNames();
        DetectPlayerGamePads();
        StartGame();
    }

    private void StartGame()
    {
        if (numOfPlayersReady > 1)
        {
            startText.SetActive(true);

            
            // Load scene or start the game
        }
    }

    private void DetectPlayerGamePads()
    {
        if (controllerNames.Count > 0 && !string.IsNullOrEmpty(controllerNames[0]))
        {
            if (Input.GetKey(KeyCode.Joystick1Button0) && !mainMenu.activeSelf)
            {
                SetNumberOfPlayerReady(0);
                ReadyPlayer(0);
            }
        }

        if (controllerNames.Count > 1 && !string.IsNullOrEmpty(controllerNames[1]))
        {
            if (Input.GetKey(KeyCode.Joystick2Button0) && !mainMenu.activeSelf)
            {
                SetNumberOfPlayerReady(1);
                ReadyPlayer(1);
            }
        }
    }

    void SetNumberOfPlayerReady(int playerNum)
    {
        if (!playerReady[playerNum].activeSelf)
        {
            numOfPlayersReady++;
        }
    }

    IEnumerator ReadyPlayer(int playerNum)
    {
        yield return new WaitForSeconds(1);

        playerReady[playerNum].SetActive(true);
        joinBtns[playerNum].SetActive(false);
    }

    void RemoveEmptyControllerNames()
    {
        controllerNames.RemoveAll(name => string.IsNullOrEmpty(name));
    }
}
