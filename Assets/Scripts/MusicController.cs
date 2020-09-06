﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuTheme;
    public AudioClip gameplayTheme;
    public AudioClip victoryTheme;
    private static MusicController playingInstance;

    void Awake()
    {
        if (playingInstance == null)
        {
            playingInstance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private static void PlayTheme(AudioClip clip)
    {
        if (playingInstance && playingInstance.audioSource.clip != clip)
        {
            playingInstance.audioSource.Stop();
            playingInstance.audioSource.clip = clip;
            playingInstance.audioSource.Play();
        }
    }

    public static void PlayMenuTheme()
    {
        if (playingInstance)
        {
            PlayTheme(playingInstance.menuTheme);
        }
    }
    public static void PlayGameplayTheme()
    {
        if (playingInstance)
        {
            PlayTheme(playingInstance.gameplayTheme);
        }
    }

    public static float PlayVictoryTheme()
    {
        if (playingInstance)
        {
            PlayTheme(playingInstance.victoryTheme);
            return playingInstance.victoryTheme.length;
        }
        return 0f;
    }
}
