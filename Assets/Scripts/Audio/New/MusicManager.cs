using UnityEngine.Audio; // should be included when working with sound.
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    
    public static MusicManager instance;

    [SerializeField] private Sound[] sounds;

    [Header("Elements")]
    [SerializeField] private Sound currentIngameTrack = null;
    [SerializeField] private float timeToFade = 1;
    //
    private string MAIN_MENU_TRACK_NAME = "Theme_Main_Menu";
    private float timeElapsed;

    // Unused
    private bool playNextTrack;
    private bool stopOldTrack;

    private bool StartDelayTime;
    private bool stateSwitch = false;
    private float TimerThreshold = 1f;


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        InitializeSoundsInSoundsArray();

        SetTracksLoopTrue();
    }

    private void InitializeSoundsInSoundsArray()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.mute = s.mute;
        }
    }

    private void Start()
    {
        SetMusicSettings();

        SetMusicVolumeToZero();

        PlayMainMenuTrackNew();
    }

    private void OnEnable()
    {
        MusicHandler.OnTriggerSwapTracks += SwapTracksNew;
        GameEvents.OnReturnToMainMenu += SwitchToMainMenuTrack;
        GameEvents.OnLevelRestarted += RestartCurrentTrack;
    }

    private void OnDisable()
    {
        MusicHandler.OnTriggerSwapTracks -= SwapTracksNew;
        GameEvents.OnReturnToMainMenu -= SwitchToMainMenuTrack;
        GameEvents.OnLevelRestarted -= RestartCurrentTrack;
    }

    #region ---------------------------------------------------Music_Tracks_Main_Functions---------------------------------------------------:

    private void SetTracksLoopTrue()
    {
        foreach (Sound s in sounds)
        {
            s.source.loop = true;
        }
    }

    private void TrackNullCheck(string name, Sound track)
    {
        if (track == null)
        {
            Debug.Log("Music:" + name + "is not found!");
            return;
        }
    }

    private void Play(string name)
    {
        Sound track = Array.Find(sounds, sound => sound.name == name);

        TrackNullCheck(name, track);
        
        PlayTrack(track);
    }

    private void PlayTrack(Sound track)
    {
        track.source.Play();
    }

    private void StopTrack(Sound track)
    {
        track.source.Stop();
    }

    private void SetMusicVolumeToZero()
    {
        foreach (Sound s in sounds)
            s.source.volume = 0f;
    }

    private void SetMuteState(bool muteState)
    {
        foreach (Sound s in sounds)
            s.source.mute = muteState;
    }

    public void SetMusicSettings()
    {
        if (PlayerPrefs.GetInt("m_Muted") == 1)
            SetMuteState(true);

        else if (PlayerPrefs.GetInt("m_Muted") == 0)
            SetMuteState(false);
    }

    #endregion


    #region ---------------------------------------------------SwapTrack_Mechanics---------------------------------------------------:

    private void PlayMainMenuTrackNew()
    {
        FadeInNextTrack(MAIN_MENU_TRACK_NAME);
    }

    private void RestartCurrentTrack()
    {
        FadeInNextTrack(currentIngameTrack.name);
    }

    private void SwitchToMainMenuTrack()
    {
        if (currentIngameTrack != null)
            SwapTracksNew(currentIngameTrack.name, MAIN_MENU_TRACK_NAME);
        else
            FadeInNextTrack(MAIN_MENU_TRACK_NAME);
    }

    private void FadeOutOldTrack(string name)
    {
        currentIngameTrack = null;

        bool shouldPlay = false;

        Sound track = Array.Find(sounds, sound => sound.name == name);

        TrackNullCheck(name, track);

        StopTrack(track);

        StartCoroutine(LerpFadeTrack(track, 1, 0, shouldPlay));
    }
    private void FadeInNextTrack(string name)
    {
        bool shouldPlay = true;

        Sound track = Array.Find(sounds, sound => sound.name == name);

        TrackNullCheck(name, track);

        currentIngameTrack = track;

        StartCoroutine(LerpFadeTrack(track, 0, 1, shouldPlay));
    }

    private IEnumerator LerpFadeTrack(Sound track, float a, float b, bool shouldPlay)
    {
        timeElapsed = 0f;

        if (shouldPlay)
            PlayTrack(track);

        while (timeElapsed < timeToFade)
        {
            track.source.volume = Mathf.Lerp(a, b, timeElapsed / timeToFade);
            timeElapsed += Time.deltaTime;

            if (!shouldPlay && timeElapsed >= timeToFade)
                StopTrack(track);

            yield return null;
        }
    }

    private void SwapTracksNew(string oldTrack, string newTrack)
    {
        FadeOutOldTrack(oldTrack);
        FadeInNextTrack(newTrack);
    }

    #endregion



    #region ---------------------------------------------------Old_Functions---------------------------------------------------:

    private IEnumerator FadeInTrack(string name)
    {
        playNextTrack = true;

        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            Debug.Log("Sound:" + name + "not found!");

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

    public IEnumerator SplashDelayTimeToPlayMainTheme()
    {
        StartCoroutine(FadeInTrack("Theme_Main_Menu"));
        yield return new WaitForSecondsRealtime(TimerThreshold);
        playNextTrack = false;
        stopOldTrack = false;
    }

    #endregion

}


/*    private void StopAllMusic()
    {
        foreach (Sound s in sounds)
            s.source.Stop();
    }*/

//track.source.Play();
/*        if (track == null)
{
    Debug.Log("Music:" + name + "is not found!");
    return;
}*/

/*    private void StopTrack(Sound track)
    {
        track.source.Stop();
    }*/

/*    private IEnumerator PlayMainMenuTrack()
    {
        FadeInNextTrack("Theme_Main_Menu");
        yield return new WaitForSecondsRealtime(TimerThreshold);
    }*/

/*    private Sound GetTrack(string name)
    {
        Sound track = Array.Find(sounds, sound => sound.name == name);
        return track;
    }*/

/*            Mute("Theme_Main_Menu");
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
            Mute("Theme_50");*/

/*            Unmute("Theme_Main_Menu");
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
            Unmute("Theme_50");*/

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
            Debug.Log("Sound:" + name + "not found!");
            return;
        }
        s.source.mute = false;
    }*/