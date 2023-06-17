using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [SerializeField]AudioSource audioSource;
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioClip[] songs;
    [SerializeField] AudioClip countDown;
    [SerializeField] AudioClip join;
    [SerializeField] AudioClip powerUpPickUp;

    private static AudioManagerScript instance;
    private void Awake() //singleton
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
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

    public void PlayCountDown()
    {
        audioSource.PlayOneShot(countDown);
    }

    public void JoinSfx()
    {
        audioSource.PlayOneShot(join);
    }

    public void PowerUpPickUp()
    {
        audioSource.PlayOneShot(powerUpPickUp);
    }
}
