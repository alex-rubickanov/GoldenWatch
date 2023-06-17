using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHandler : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Joystick1Button7) || Input.GetKeyDown(KeyCode.Joystick2Button7)) {
            PauseMenu();
        }
    }

    public void PauseMenu()
    {
        if (pauseMenu.activeSelf) {
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject m in players) {
                m.GetComponent<Movement>().enabled = true;
                m.GetComponent<Rotation>().enabled = true;
                if (m.GetComponentInChildren<Weapon>() != null) {
                    m.GetComponentInChildren<Weapon>().enabled = true;
                }
            }

        } else {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject m in players) {
                m.GetComponent<Movement>().enabled = false;
                m.GetComponent<Rotation>().enabled = false;
                if (m.GetComponentInChildren<Weapon>() != null) {
                    m.GetComponentInChildren<Weapon>().enabled = false;
                }
            }
        }
    }

    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
