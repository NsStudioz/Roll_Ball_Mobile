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
        OnMusicMuteStateInvoked_SetMusicSettings();

        SetMusicVolumeToZero();

        PlayMainMenuTrackNew();
    }

    private void OnEnable()
    {
        OptionsEvents.OnMusicMuteState += OnMusicMuteStateInvoked_SetMusicSettings;
        MusicHandler.OnTriggerSwapTracks += SwapTracksNew;
        GameEvents.OnReturnToMainMenu += SwitchToMainMenuTrack;
        GameEvents.OnLevelRestarted += RestartCurrentTrack;
    }

    private void OnDisable()
    {
        OptionsEvents.OnMusicMuteState -= OnMusicMuteStateInvoked_SetMusicSettings;
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

    public void OnMusicMuteStateInvoked_SetMusicSettings()
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
 

}