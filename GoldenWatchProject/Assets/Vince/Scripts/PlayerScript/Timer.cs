using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Image timerImg;
    [SerializeField] float timerRate = 0.05f;

    bool startTimer;
    public bool StartTimer
    {
        set { startTimer = value; }
    }
    private void Update()
    {
        if (startTimer)
        {
            timerImg.fillAmount -= Time.deltaTime * timerRate;
        }
        else
        {
            timerImg.fillAmount = timerImg.fillAmount;
        }
    }
}
