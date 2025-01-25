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
    // UNIVERSAL
    public void ButtonClickSound()
    {
        sfxSource.pitch = Random.Range(0.8f, 1f);
    }

    // MAIN MENU SCENE

    // GAME SCENE
    public void HitEnemySound()
    {
        sfxSource.pitch = 1;
        sfxSource.PlayOneShot(sfxClips[0]);
    }

}
