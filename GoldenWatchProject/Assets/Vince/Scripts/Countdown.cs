using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] GameObject cdObject;
    [SerializeField] Image cdImage;
    [SerializeField] Sprite[] countDown;
    [SerializeField] float timeInterval = 2f;
    [SerializeField] float activeDuration = 1f;
    [SerializeField] int cdNum;

    Animator anim;

    private void OnEnable()
    {
        cdImage.sprite = countDown[0];
        anim = GetComponent<Animator>();
        StartCoroutine(NextImage());
    }
    IEnumerator NextImage()
    {
        cdObject.SetActive(false);

        while (cdNum < countDown.Length)
        {
            yield return new WaitForSeconds(timeInterval);
            anim.SetTrigger("Activate");
            cdObject.SetActive(true);
            yield return new WaitForSeconds(activeDuration);
            cdObject.SetActive(false);
            cdNum++;
            if (cdNum < countDown.Length)
            {
                if (cdNum == countDown.Length - 1)
                {
                    activeDuration = 1f;
                }

                cdImage.sprite = countDown[cdNum];
            }
            else
            {
                print("Game starts!");
                StopAllCoroutines();
                Destroy(gameObject);
            }
        }
    }
}
