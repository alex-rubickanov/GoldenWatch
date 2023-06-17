using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicRadioScript : MonoBehaviour
{
    private AudioSource musicSource;
    [SerializeField] AudioClip[] songs;

    private void Start()
    {
        musicSource= GetComponent<AudioSource>();
    }

    private void PlayMusic()
    {
        if (!musicSource.isPlaying) {
            musicSource.PlayOneShot(songs[Random.Range(0, songs.Length)], 0.3f);
        }
    }


}
