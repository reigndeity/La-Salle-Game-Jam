using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

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
    public void GameMusic()
    {
        musicSource.clip = musicClips[1];
        musicSource.Play();
        musicSource.loop = true;
    }

    public void GameOverMusic()
    {
        musicSource.Stop();
        musicSource.clip = musicClips[2];
        musicSource.Play();
        musicSource.loop = false;
    }

    public void OnButtonClickSFX()
    {
        sfxSource.PlayOneShot(sfxClips[0]);
    }

    public void OnBellClickSFX()
    {
        sfxSource.PlayOneShot(sfxClips[1]);
    }

    public void SpawnSFX()
    {
        sfxSource.volume = 0.75f;
        sfxSource.PlayOneShot(sfxClips[2]);
    }

    public void EnemyAngry()
    {
        sfxSource.volume = 0.8f;
        sfxSource.PlayOneShot(sfxClips[3]);
    }

    public void EnemyEndPoint()
    {
        sfxSource.volume = 0.8f;
        sfxSource.PlayOneShot(sfxClips[4]);
    }

    public void FinishedOrder()
    {
        sfxSource.volume = 0.5f;
        sfxSource.PlayOneShot(sfxClips[5]);
    }

    public void ShootAndReload()
    {
        sfxSource.volume = 1f;
        sfxSource.PlayOneShot(sfxClips[6]);
    }

    public void ReloadOnly()
    {
        sfxSource.volume = 1f;
        sfxSource.PlayOneShot(sfxClips[7]);
    }
    public void ReadySFX()
    {
        sfxSource.volume = 0.25f;
        sfxSource.PlayOneShot(sfxClips[8]);

    }
    public void GoSFX()
    {
        sfxSource.volume = 0.25f;
        sfxSource.PlayOneShot(sfxClips[9]);

    }
    public void FLavorClickSFX()
    {
        sfxSource.volume = 1f;
        sfxSource.PlayOneShot(sfxClips[10]);
    }



}
