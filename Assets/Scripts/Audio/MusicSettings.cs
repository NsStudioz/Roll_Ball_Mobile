using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{

    [SerializeField] private Button musicMuteBtn;
    [SerializeField] private Sprite musicMutedImg;
    [SerializeField] private Sprite musicUnmutedImg;
    private bool m_Muted = false;

    private void OnEnable()
    {
        musicMuteBtn.onClick.AddListener(() =>
        {
            SetSoundMuteState();
            UpdateButtonImage();
            UpdateMusicState();
        });
    }

    private void OnDisable()
    {
        musicMuteBtn.onClick.RemoveAllListeners();
    }

    private void SetSoundMuteState()
    {
        m_Muted = !m_Muted;
    }

    private void UpdateButtonImage()
    {
        if (m_Muted)
            musicMuteBtn.image.sprite = musicMutedImg;
        else
            musicMuteBtn.image.sprite = musicUnmutedImg;
    }

    private void UpdateMusicState()
    {
        if (!m_Muted)
            TriggerOnMusicMute_Event();

        SaveMusicSettings();
        TriggerOnMusicMuteState_Event(); // update mute state in AudioManager
    }

    private void TriggerOnMusicMuteState_Event()
    {
        UIEvents.OnMusicMuteState?.Invoke();
    }

    private void TriggerOnMusicMute_Event()
    {
        UIEvents.OnMusicMute?.Invoke();
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("m_Muted"))
            PlayerPrefs.SetInt("m_Muted", 0);
        else
            LoadMusicSettings();

        UpdateButtonImage();
    }

    private void LoadMusicSettings()
    {
        m_Muted = PlayerPrefs.GetInt("m_Muted") == 1;
    }

    private void SaveMusicSettings()
    {
        PlayerPrefs.SetInt("m_Muted", m_Muted ? 1 : 0);
    }
}