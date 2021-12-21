using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private bool random;
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip heartBeat;

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
        foreach(var source in GetComponents<AudioSource>())
        {
            source.volume = volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(musicSource.isPlaying)
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

    private float currentTime;

    public void Pause()
    {
        currentTime = musicSource.time;
        musicSource.Stop();
        heartBeatSource.Stop();
    }

    public void Play(float time = 0)
    {

    }
}
