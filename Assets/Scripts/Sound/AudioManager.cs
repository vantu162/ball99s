using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource; // Reference to the Audio Source

    public AudioSource vfxAudioSource; // Reference to the Audio Source

    public AudioClip soundBox;
    public AudioClip soundStar;
    public AudioClip soundGold;

    public static AudioManager Instance;


    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        audioSource.clip = soundBox;
        audioSource.Play();
    }

    // Method to play the sound
    public void PlaySFX()
    {
        vfxAudioSource.clip = soundBox;
        vfxAudioSource.PlayOneShot(soundBox);
    }

}
