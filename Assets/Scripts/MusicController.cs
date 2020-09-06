using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;
    private static MusicController playingInstance;

    void Awake()
    {
        if (playingInstance == null)
        {
            playingInstance = this;
            DontDestroyOnLoad(gameObject);
            audioSource.Play();
        }
    }
}
