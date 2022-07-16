using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; } //gives permission to other scripts to GET this instance, but not to modify it

    private AudioSource source;

    private void Awake()
    {
        instance = this;
        source = GetComponent<AudioSource>();

    }

    public void PlaySound(AudioClip sound)
    {
        source.PlayOneShot(sound);

    }


}
