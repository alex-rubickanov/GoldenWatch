using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownStarter : MonoBehaviour
{
    [SerializeField] GameObject[] playerUis;
    [SerializeField] GameObject[] playerMangers;
    [SerializeField] GameObject countdown;
    void Start()
    {
        EnableAllObjects(false);
    }

    private void Update()
    {
        CountDownChecker();
    }

    private void CountDownChecker()
    {
        if (countdown == null)
        {
            EnableAllObjects(true);
        }
    }

    void EnableAllObjects(bool value)
    {
        for (int i = 0; i < playerUis.Length; i++)
        {
            playerMangers[i].SetActive(value);
            playerUis[i].SetActive(value);
        }
    }
}
