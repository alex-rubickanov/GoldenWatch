using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Select Role")]
    [SerializeField] PlayerRole playerNum;

    string playerRole;
    public enum PlayerRole{
        Player1 = 0,
        Player2 = 1,
        Player_KB = 2
    }

    private void Start()
    {
        CheckPlayerRole();
    }

    private void CheckPlayerRole()
    {
        if(playerNum == PlayerRole.Player1)
        {
            playerRole = "P1_";
        }
        else if(playerNum == PlayerRole.Player2)
        {
            playerRole = "P2_";
        }
        else if (playerNum == PlayerRole.Player_KB) 
        {
            playerRole = "P1_KB_";
        }
    }

    public string GetPlayerRole
    {
        get
        {
            return playerRole;
        }
    }

    public PlayerRole GetPlayerNum()
    {
        return playerNum;
    }
}
