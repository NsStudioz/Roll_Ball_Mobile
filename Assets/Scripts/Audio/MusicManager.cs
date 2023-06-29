using UnityEngine.Audio; // should be included when working with sound.
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    public bool playNextTrack;
    public bool stopOldTrack;
    public bool StartDelayTime;
    public bool stateSwitch = false;
    //
    [SerializeField] public int currentSceneIndex;
    public float timeElapsed;
    public float timeToFade;
    //
    private float TimerThreshold = 1f;
    //
    public Sound[] sounds;
    //
    public static MusicManager instance;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
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
        SetMusicSettings();

        SetMusicVolumeToZero();

        StartCoroutine(SplashDelayTimeToPlayMainTheme());


        foreach(Sound s in sounds)
        {
            s.source.loop = true;
        }
    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void Mute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "not found!");
            return;
        }
        s.source.mute = true;
    }

    public void Unmute(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "not found!");
            return;
        }
        s.source.mute = false;
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("Music:" + name + "is not found!");
            return;
        }
        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("Music:" + name + "is not found!");
            return;
        }
        s.source.Stop();
    }

    public void StopAllMusic()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void SetMusicVolumeToZero()
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = 0f;
        }
    }

    public void SetMusicSettings()
    {
        if (PlayerPrefs.GetInt("m_Muted") == 1)
        {
            Mute("Theme_Main_Menu");
            Mute("Theme_1_10");
            Mute("Theme_11_15");
            Mute("Theme_16_20");
            Mute("Theme_21_25");
            Mute("Theme_26_29");
            Mute("Theme_30_32");
            Mute("Theme_33_37");
            Mute("Theme_38_40");
            Mute("Theme_41_47");
            Mute("Theme_48_49");
            Mute("Theme_50");
        }
        else if (PlayerPrefs.GetInt("m_Muted") == 0)
        {
            Unmute("Theme_Main_Menu");
            Unmute("Theme_1_10");
            Unmute("Theme_11_15");
            Unmute("Theme_16_20");
            Unmute("Theme_21_25");
            Unmute("Theme_26_29");
            Unmute("Theme_30_32");
            Unmute("Theme_33_37");
            Unmute("Theme_38_40");
            Unmute("Theme_41_47");
            Unmute("Theme_48_49");
            Unmute("Theme_50");
        }
    }

    private IEnumerator FadeInTrack(string name)
    {
        playNextTrack = true;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "not found!");
        }

        timeElapsed = 0f;

        if (playNextTrack)
        {
            s.source.Play();

            while (timeElapsed < timeToFade)
            {
                s.source.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
        }
    }

    private IEnumerator FadeOutTrack(string name)
    {
        stopOldTrack = true;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound:" + name + "not found!");
        }

        timeElapsed = 0f;

        if (stopOldTrack)
        {
            while (timeElapsed < timeToFade)
            {
                s.source.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            s.source.Stop();
        }
    }

    private IEnumerator DelayTimeToSwitchBools()
    {
        StartDelayTime = true;

        yield return new WaitForSecondsRealtime(TimerThreshold);

        StartDelayTime = false;
        playNextTrack = false;
        stopOldTrack = false;
    }

    public void SwapTracks(string oldTrack, string newTrack)
    {
        StartCoroutine(FadeOutTrack(oldTrack)); // stop old track, do a fadeout.
        StartCoroutine(FadeInTrack(newTrack)); // start new track, do a fadein.

        StartCoroutine(DelayTimeToSwitchBools()); // start new track, do a fadein.
    }

    private IEnumerator SplashDelayTimeToPlayMainTheme()
    {
        StartCoroutine(FadeInTrack("Theme_Main_Menu"));

        yield return new WaitForSecondsRealtime(TimerThreshold);

        playNextTrack = false;
        stopOldTrack = false;

    }

}
