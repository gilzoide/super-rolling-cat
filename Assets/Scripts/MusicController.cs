using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip menuTheme;
    public AudioClip gameplayTheme;
    public AudioClip readyGoClip;
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
            playingInstance.audioSource.loop = true;
            PlayTheme(playingInstance.menuTheme);
        }
    }
    public static void PlayGameplayTheme()
    {
        if (playingInstance)
        {
            playingInstance.audioSource.loop = true;
            PlayTheme(playingInstance.gameplayTheme);
        }
    }

    public static float PlayVictoryTheme()
    {
        if (playingInstance)
        {
            playingInstance.audioSource.loop = false;
            PlayTheme(playingInstance.victoryTheme);
            return playingInstance.victoryTheme.length;
        }
        return 0f;
    }

    public static float PlayReadyGoClip()
    {
        if (playingInstance)
        {
            playingInstance.audioSource.PlayOneShot(playingInstance.readyGoClip);
            return 1.7f; // hardcode nas últimas 3h, quem nunca
        }
        return 0f;
    }
}
