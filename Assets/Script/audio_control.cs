using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class audio_control : MonoBehaviour
{
    public AudioClip[] impact =new AudioClip[10];
    private AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void audio_eat(){
        audiosource.PlayOneShot(impact[0],0.5f);
    }

    public void audio_shoot(){
        audiosource.PlayOneShot(impact[1],0.5f);
    }

    public void audio_laser(){
        audiosource.PlayOneShot(impact[2],0.5f);
    }

    public void audio_bomb(){
        audiosource.PlayOneShot(impact[3],0.5f);
    }
}
