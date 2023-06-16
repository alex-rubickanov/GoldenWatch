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
    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(Exit);
    }

    void StartGame()
    {
        JoinPanel.SetActive(true);
        mainMenu.SetActive(false);
    }

    void Exit()
    {
        Application.Quit();
    }
}
