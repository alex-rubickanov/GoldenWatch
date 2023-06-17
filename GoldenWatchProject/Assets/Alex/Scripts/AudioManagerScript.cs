using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip[] songs;


    private void Start()
    {
    }
    private void Update()
    {
        PlayMusic();
    }
    public void PlayGunSound(Weapon weapon, float volume)
    {
        audioSource.PlayOneShot(weapon.gunShotSound, volume);
    }

    private void PlayMusic()
    {
        if (!musicSource.isPlaying) {
            musicSource.PlayOneShot(songs[Random.Range(0, songs.Length)], 0.1f);
        }
    }

}
