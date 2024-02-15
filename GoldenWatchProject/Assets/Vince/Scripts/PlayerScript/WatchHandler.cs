using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WatchHandler : MonoBehaviour
{
    [SerializeField] GameObject uiTimer;
    [SerializeField] PlayerRole playerRole;
    [SerializeField] bool goldWatch;
    [SerializeField] GameObject goldWatchObj;
    [SerializeField] GameObject goldArrow;
    PlayerStatus playerStatus;
    static bool arrowDisabled;
    bool goldSpawned;

    enum PlayerRole
    {
        Player1,
        Player2
    }
    private void Awake()
    {
        playerStatus = GetComponent<PlayerStatus>();

        if (playerRole == PlayerRole.Player1)
        {
            uiTimer = GameObject.FindGameObjectWithTag("Player1Timer");

        }
        else if (playerRole == PlayerRole.Player2)
        {
            uiTimer = GameObject.FindGameObjectWithTag("Player2Timer");
        }
    }

    private void Update()
    {
        GoldHasDetected();
    }

    private void GoldHasDetected()
    {
        if (goldWatch)
        {
            goldArrow.SetActive(true);
            SwitchTimerColor(Color.white);
            uiTimer.GetComponent<Timer>().StartTimer = false;
        }
        else if (playerStatus.GetHealth() <= 0)
        {
            goldArrow.SetActive(false);
            SwitchTimerColor(Color.red);
            uiTimer.GetComponent<Timer>().StartTimer = true;
        }
        else
        {
            goldArrow.SetActive(false);
            SwitchTimerColor(Color.red);
            uiTimer.GetComponent<Timer>().StartTimer = true;
        }
        if (playerStatus.GetHealth() <= 0 && goldWatch)
        {
            if (!goldSpawned)
            {
                goldSpawned = true;
                Instantiate(goldWatchObj, transform.position, Quaternion.identity);
            }
        }
    }

    void SwitchTimerColor(Color color)
    {
        uiTimer.GetComponent<Image>().color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GoldWatch")
        {
            goldWatch = true;
            if (!arrowDisabled)
            {
                arrowDisabled = true;
                GameObject goldwatchArrow = collision.gameObject.transform.Find("Arrow").gameObject;
                if (goldwatchArrow != null)
                {
                    goldwatchArrow.SetActive(false);
                }
            }

            Destroy(collision.gameObject.gameObject);
        }
    }

    public bool GoldWatch
    {
        set
        {
            goldWatch = value;
        }
    }

    IEnumerator SpawnWach()
    {
        yield return new WaitForSeconds(1);
    }
}
