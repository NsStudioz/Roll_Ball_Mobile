using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettings : MonoBehaviour
{
    MusicManager musicManager;

    [SerializeField] GameObject musicButtonOn;
    [SerializeField] GameObject musicButtonOff;

    [SerializeField] bool m_Muted = false;
    //

    [SerializeField] private Button musicMuteBtn;
    [SerializeField] private Sprite musicMutedImg;
    [SerializeField] private Sprite musicUnmutedImg;


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
        OptionsEvents.OnMusicMuteState?.Invoke();
    }

    private void TriggerOnMusicMute_Event()
    {
        OptionsEvents.OnMusicMute?.Invoke();
    }

    private void Awake()
    {
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("m_Muted"))
        {
            PlayerPrefs.SetInt("m_Muted", 0);
        }
        else
        {
            LoadMusicSettings();
        }

        UpdateButtonIcon();
    }

    public void MusicOn()
    {
        m_Muted = false;
        FindObjectOfType<AudioManager>().Play("AudioButtonClick");
        UpdateButtonIcon();
        SaveMusicSettings();
        musicManager.SetMusicSettings();
    }

    public void MusicOff()
    {
        m_Muted = true;
        UpdateButtonIcon();
        SaveMusicSettings();
        musicManager.SetMusicSettings();
    }

    private void UpdateButtonIcon()
    {
        if (m_Muted == false)
        {
            musicButtonOn.SetActive(true);
            musicButtonOff.SetActive(false);
        }
        else
        {
            musicButtonOn.SetActive(false);
            musicButtonOff.SetActive(true);
        }
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
