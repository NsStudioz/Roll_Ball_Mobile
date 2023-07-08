using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Handles SFX:
    public static SoundManager Instance;

    [SerializeField] private Sound[] sounds;

    private void Awake()
    {
        if (Instance == null) 
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        Initialize();
    }

    private void OnEnable()
    {
        UIEvents.OnSoundMuteState += OnSoundMuteStateInvoked_SetSoundSettings;
    }

    private void OnDisable()
    {
        UIEvents.OnSoundMuteState -= OnSoundMuteStateInvoked_SetSoundSettings;
    }

    private void Initialize()
    {
        foreach (Sound s in sounds) // check in sounds array.
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            //
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    private void Start()
    {
        OnSoundMuteStateInvoked_SetSoundSettings();
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name); // Array.Find (Find the 'sounds array',
                                                                   // we then want to find the sound where sound.name is equal to the name).
        SoundNullCheck(s);

        s.source.Play();
    }

    private void SoundNullCheck(Sound sound)
    {
        if (sound == null)                                             
        {
            Debug.Log("Sound:" + name + "not found!");
            return;
        }
    }

    private void MuteState(bool muteState)
    {
        foreach(Sound s in sounds)
            s.source.mute = muteState;
    }

    private void OnSoundMuteStateInvoked_SetSoundSettings()
    {
        if(PlayerPrefs.GetInt("muted") == 1)
            MuteState(true);
        else if (PlayerPrefs.GetInt("muted") == 0)
            MuteState(false);
    }
}
