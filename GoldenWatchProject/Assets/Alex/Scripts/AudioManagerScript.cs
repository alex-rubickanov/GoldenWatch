using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayGunSound(Weapon weapon, float volume)
    {
        audioSource.PlayOneShot(weapon.gunShotSound, volume);
    }
}
