using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAudio : MonoBehaviour
{
    public AudioClip music;
    public static AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip=music;
    }
}
