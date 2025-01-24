using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;
    [Header("Music Properties")]
    public AudioSource musicSource;
    public AudioClip[] musicClips;
    [Header("SFX Properties")]
    public AudioSource sfxSource;
    public AudioClip[] sfxClips;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            
        }
    }
}
