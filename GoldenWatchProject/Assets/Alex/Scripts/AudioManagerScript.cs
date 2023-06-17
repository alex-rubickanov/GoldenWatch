using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    AudioSource audioSource;
    AudioSource musicSource;
    [SerializeField] AudioClip[] songs;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayGunSound(Weapon weapon, float volume)
    {
        audioSource.PlayOneShot(weapon.gunShotSound, volume);
    }

    private void PlayMusic()
    {
        audioSource.PlayOneShot(songs[Random.Range(0, songs.Length)]);
    }

}
