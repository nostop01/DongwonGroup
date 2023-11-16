using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SFX : MonoBehaviour
{
    static AudioSource audioSource;
    public static AudioClip clip;
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); ;
        clip = Resources.Load<AudioClip>("Coin1");
    }

    public static void SoundPlay()
    {
        audioSource.PlayOneShot(clip);
    }
}
