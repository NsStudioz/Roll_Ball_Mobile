using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{

    [SerializeField] private Button SoundMuteBtn;
    [SerializeField] private Sprite soundMutedImg;
    [SerializeField] private Sprite soundUnmutedImg;
    private bool muted = false;

    private void OnEnable()
    {
        SoundMuteBtn.onClick.AddListener(() =>
        {
            SetSoundMuteState();
            UpdateButtonImage();
            UpdateSoundState();
        });
    }

    private void OnDisable()
    {
        SoundMuteBtn.onClick.RemoveAllListeners();
    }

    private void SetSoundMuteState()
    {
        muted = !muted;
    }

    private void UpdateButtonImage()
    {
        if (muted)
            SoundMuteBtn.image.sprite = soundMutedImg;
        else
            SoundMuteBtn.image.sprite = soundUnmutedImg;
    }

    private void UpdateSoundState()
    {
        if (!muted)
            TriggerOnSoundMuteClicked_Event();

        SaveAudioSettings();
        TriggerOnSoundMuteState_Event(); // update mute state in AudioManager
    }


    void Start()
    {
        if (!PlayerPrefs.HasKey("muted")) // if there are no saved data from previous game session
        {
            PlayerPrefs.SetInt("muted", 0); // we will set "muted" to 0 which means "muted" = false
            LoadAudioSettings(); // load the current settings.
        }
        else
            LoadAudioSettings(); // if there are saved data from previous game sessions, load the saved settings instead.

        UpdateButtonImage();
    }

    private void LoadAudioSettings()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void SaveAudioSettings()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0); // if "muted" = true, we will save it as "1", if false, we will save it as "0"
    }

    private void TriggerOnSoundMuteClicked_Event()
    {
        UIEvents.OnSoundMute?.Invoke(); // Listeners: AudioManager & AudioHandler
    }

    private void TriggerOnSoundMuteState_Event()
    {
        UIEvents.OnSoundMuteState?.Invoke(); // Listeners: AudioManager
    }
}
