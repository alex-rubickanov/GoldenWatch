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
    PlayerStatus playerStatus;
    bool goldSpawned;

    enum PlayerRole
    {
        Player1,
        Player2
    }
    private void OnEnable()
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
            SwitchTimerColor(Color.white);
            uiTimer.GetComponent<Timer>().StartTimer = false;
        }
        else if (playerStatus.GetHealth() <= 0)
        {

            SwitchTimerColor(Color.red);
            uiTimer.GetComponent<Timer>().StartTimer = true;
        }
        else
        {
            
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
