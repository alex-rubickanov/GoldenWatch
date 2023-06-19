using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerDetect : MonoBehaviour
{
    //[SerializeField] List<string> controllerNames;
    [SerializeField] GameObject[] playerReady;
    [SerializeField] GameObject[] joinBtns;
    [SerializeField] GameObject startText;
    AudioManagerScript audioManager;
    public int numOfPlayersReady;
    [SerializeField] GetControllers gc;
    private void OnEnable()
    {
        audioManager = FindObjectOfType<AudioManagerScript>();
    }

    void Update()
    {
        //controllerNames = new List<string>(Input.GetJoystickNames());
        RemoveEmptyControllerNames();
        DetectPlayerGamePads();
        StartGame();


    }

    private void StartGame()
    {
        if (numOfPlayersReady > 1)
        {
            startText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7))
            {
                SceneManager.LoadScene("MainGame");
                audioManager.JoinSfx();
            }
            // Load scene or start the game

        }
    }

    private void DetectPlayerGamePads()
    {
        if (/*gc.controllerNames.Count > 0 && numOfPlayersReady < 1 && !string.IsNullOrEmpty(gc.controllerNames[0])*/ true)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0)) {
                SetNumberOfPlayerReady(0);
                playerReady[0].SetActive(true);
                joinBtns[0].SetActive(false);
                audioManager.JoinSfx();
            }
        }

        if (/*gc.controllerNames.Count > 1 && numOfPlayersReady < 2 && !string.IsNullOrEmpty(gc.controllerNames[1]*/true)
        {
            if (Input.GetKeyDown(KeyCode.Joystick2Button0) || Input.GetKeyDown(KeyCode.Return))
            {
                SetNumberOfPlayerReady(1);
                playerReady[1].SetActive(true);
                joinBtns[1].SetActive(false);
                audioManager.JoinSfx();
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

    void RemoveEmptyControllerNames()
    {
        gc.controllerNames.RemoveAll(name => string.IsNullOrEmpty(name));
    }
}
