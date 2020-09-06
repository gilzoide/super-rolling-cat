using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayAudioOnSelect : MonoBehaviour, ISelectHandler
{
    public AudioSource audioSource;
    public AudioClip clip;

    void Awake()
    {
        if (!audioSource)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        audioSource.PlayOneShot(clip);
    }
}
