using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource musicSource;
    [SerializeField] private AudioClip starting_music;
    [SerializeField] private AudioClip game_music;
    
    private static MusicPlayer instance = null;
    public static MusicPlayer Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        musicSource.PlayOneShot(starting_music);
        musicSource.PlayScheduled(AudioSettings.dspTime + starting_music.length);

    }
}
