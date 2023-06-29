using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager Instance;

    void Awake()
    {
        if (Instance == null) { Instance = this; } // singleton pattern
        else
        {
            Destroy(gameObject);
            return; // so that no more code is called before we destroy this gameObject.
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

/*    void Update()
    {
        //SetSoundSettings();
    }*/

/*            Mute("PlayerJump");
Mute("PlayerHit");
Mute("PlayerDeath");
Mute("PlayerSound4");
Mute("ButtonClick");
Mute("AudioButtonClick");
Mute("LevelChoosed");
Mute("Timer");
Mute("JumpsPickup");
Mute("TimePickup");
Mute("LevelCompleted");
Mute("BackButtonClick");
Mute("MenuButtonClick");
Mute("KeyPickup");
Mute("BlockUnlock");*/


/*            Unmute("PlayerJump");
            Unmute("PlayerHit");
            Unmute("PlayerDeath");
            Unmute("PlayerSound4");
            Unmute("ButtonClick");
            Unmute("AudioButtonClick");
            Unmute("LevelChoosed");
            Unmute("Timer");
            Unmute("JumpsPickup");
            Unmute("TimePickup");
            Unmute("LevelCompleted");
            Unmute("BackButtonClick");
            Unmute("MenuButtonClick");
            Unmute("KeyPickup");
            Unmute("BlockUnlock");*/

/*    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "not found!");
            return;
        }
        s.source.mute = true;
    }*/

/*    public void Unmute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:"  + name + "not found!");
            return;
        }
        s.source.mute = false;
    }*/
