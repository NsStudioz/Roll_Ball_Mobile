using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    public static AudioManager Instance;

    public Sound[] sounds;

    void Awake()
    {
        if (Instance == null) { Instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    private void Initialize()
    {
        foreach (Sound s in sounds) // check in sounds array.
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    void Start()
    {
        SetSoundSettings();
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // Array.Find (Find the 'sounds array', 
        if (s == null)                                             // we then want to find the sound where sound.name is equal to the name).
        {
            Debug.Log("Sound:" + name + "not found!");
            return; 
        }
        s.source.Play();
    }

    public void MuteState(bool muteState)
    {
        foreach(Sound s in sounds)
        {
            s.source.mute = muteState;
        }
    }

    public void SetSoundSettings()
    {
        if(PlayerPrefs.GetInt("muted") == 1)
        {
            MuteState(true);
        }
        else if (PlayerPrefs.GetInt("muted") == 0)
        {
            MuteState(false);
        }
    }
}
