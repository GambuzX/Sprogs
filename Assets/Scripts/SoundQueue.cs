using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundQueue : MonoBehaviour
{
    public AudioClip[] audios;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        Invoke("SongPlay1",0f);
        Invoke("SongPlay3",1f);
        Invoke("SongPlay2",1.7f);
    }

    void SongPlay1(){
        audioSource.clip = audios[0];
        audioSource.Play();
    }
    void SongPlay2(){
        audioSource.clip = audios[1];
        audioSource.Play();
    }
    void SongPlay3(){
        audioSource.clip = audios[2];
        audioSource.Play();
    }
}
