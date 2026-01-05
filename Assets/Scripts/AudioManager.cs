using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private bool random;
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip heartBeat;

    [SerializeField, Range(0f, 1f)] private float musicVolume;
    [SerializeField, Range(0f, 1f)] private float heartBeatVolume;

    private AudioSource musicSource;
    private AudioSource heartBeatSource;
    private int currentTrack = 0;

    void Start()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = false;
        musicSource.playOnAwake = true;

        heartBeatSource = gameObject.AddComponent<AudioSource>();
        heartBeatSource.playOnAwake = false;
        heartBeatSource.loop = true;
        heartBeatSource.clip = heartBeat;

        if(random)
        {
            currentTrack = UnityEngine.Random.Range(0, musicClips.Length);
        }

        musicSource.clip = musicClips[currentTrack];

        SetVolume(0.75f);
    }

    public void SetVolume(float volume)
    {
        heartBeatSource.volume = volume * heartBeatVolume;
        musicSource.volume = volume * musicVolume;
    }

    // Update is called once per frame
    void Update()
    {
        if(musicSource.isPlaying && !GameController.Instance.IsPaused)
        {
            PlayNext();
        }
    }

    private void PlayNext()
    {
        if (random)
        {
            currentTrack = UnityEngine.Random.Range(0, musicClips.Length);
        }
        else
        {
            currentTrack++;
            currentTrack %= musicClips.Length;
        }

        musicSource.clip = musicClips[currentTrack];
        musicSource.Play();
    }

    public void Pause()
    {
        musicSource.Pause();
        heartBeatSource.Pause();
    }

    public void UnPause()
    {
        musicSource.Play();

        if(GameController.Instance.IsLowTime)
        {
            heartBeatSource.Play();
        }
    }

    public void heartBeatPitch(float pitch)
    {
        heartBeatSource.pitch = pitch;
    }

    public void startHeartBeat()
    {
        if(!heartBeatSource.isPlaying)
        {
            heartBeatSource.Play();
        }
    }

    public void stopHeartBeat()
    {
        heartBeatSource.Stop();
    }    
}
