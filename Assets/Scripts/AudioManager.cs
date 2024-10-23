using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource audioSource;
    public AudioSource fxSource;

    public Sound[] musicTracks;
    public Sound[] specialFx;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        Sound track = System.Array.Find(musicTracks, sound => sound.name == name);
        if (track == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
        audioSource.clip = track.clip;
        audioSource.Play();
    }

    public void PlaySound(string name)
    {
        Sound sfx = System.Array.Find(specialFx, sound => sound.name == name);
        if (sfx == null)
        {
            Debug.LogWarning("FX: " + name + " not found");
            return;
        }
        fxSource.clip = sfx.clip;
        fxSource.Play();
    }
    
}
