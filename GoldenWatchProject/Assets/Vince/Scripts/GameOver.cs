using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Image player1Timer;
    [SerializeField] Image player2Timer;
    [SerializeField] Sprite[] playerWinUI;
    [SerializeField] GameObject gameOverUi;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckWhichTimerIsDone();
    }

    private void CheckWhichTimerIsDone()
    {
        if(player1Timer.fillAmount <= 0)
        {
            SetGameOver(playerWinUI[1]);
        }else if(player2Timer.fillAmount <= 0)
        {
            SetGameOver(playerWinUI[0]);
        }
    }

    void SetGameOver(Sprite playerWinNum)
    {
        gameOverUi.SetActive(true);
        gameOverUi.transform.Find("PlayerWinner").GetComponent<Image>().sprite = playerWinNum;
        Time.timeScale = 0f;
    }

    
}
