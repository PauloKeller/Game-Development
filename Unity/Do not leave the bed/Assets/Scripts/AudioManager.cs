using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioClip spikeAudioClipe;
    [SerializeField]
    AudioClip interactionAudioClipe;
    [SerializeField]
    AudioClip gameOverAudioClip;
    [SerializeField]
    AudioClip winGameAudioClip;


    AudioSource audioSource;

    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.Log("AudioManager is null");
            }

            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySpikeClip() 
    { 
        audioSource.PlayOneShot(spikeAudioClipe);
    }

    public void PlayInteractionAudioClip() 
    {
        audioSource.PlayOneShot(interactionAudioClipe);
    }

    public void PlayGameOverAudioClip()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(gameOverAudioClip);
    }

    public void PlayWinGameAudioClip()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(winGameAudioClip);
    }
}
