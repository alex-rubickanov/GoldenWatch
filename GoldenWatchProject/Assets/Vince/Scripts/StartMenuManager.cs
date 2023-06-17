using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject JoinPanel;
    [SerializeField] ControllerDetect cd;
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(Exit);
        cd.enabled = false;
    }

    void StartGame()
    {
        JoinPanel.SetActive(true);
        mainMenu.SetActive(false);
        StartCoroutine(EnableControllerDetection());
    }

    IEnumerator EnableControllerDetection()
    {
        yield return new WaitForSeconds(1);
        cd.enabled = true;
    }

    void Exit()
    {
        Application.Quit();
    }
}
