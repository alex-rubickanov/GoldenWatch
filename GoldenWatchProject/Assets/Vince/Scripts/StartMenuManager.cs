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
        cd.enabled = false;
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(Exit);
    }

    void StartGame()
    {
        Time.timeScale = 1f;
        StartCoroutine(enableControllers());
        JoinPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    IEnumerator enableControllers()
    {
        yield return new WaitForSeconds(1);
        cd.enabled = true;
    }

    void Exit()
    {
        Application.Quit();
    }
}
