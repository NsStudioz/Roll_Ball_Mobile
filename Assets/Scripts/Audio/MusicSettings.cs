using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSettings : MonoBehaviour
{
    MusicManager musicManager;

    [SerializeField] GameObject musicButtonOn;
    [SerializeField] GameObject musicButtonOff;

    [SerializeField] bool m_Muted = false;
    
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
