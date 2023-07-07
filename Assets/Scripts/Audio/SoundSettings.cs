using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{

    public static SoundSettings soundSettings;
    [SerializeField] GameObject soundButtonOn;
    [SerializeField] GameObject soundButtonOff;
    [SerializeField] bool muted = false;

    AudioManager audioManager;

    private void Awake()
    {
        GameObject forAudioManager = GameObject.Find("AudioManager");
        audioManager = forAudioManager.GetComponent<AudioManager>();
    }

    void Start()
    {
        if (!PlayerPrefs.HasKey("muted")) // if there are no saved data from previous game session
        {
            PlayerPrefs.SetInt("muted", 0); // we will set "muted" to 0 which means "muted" = false
            LoadAudioSettings(); // load the current settings.
        }
        else
        {
            LoadAudioSettings(); // if there are saved data from previous game sessions, load the saved settings instead.
        }

        UpdateButtonIcon();
    }

    public void UpdateButtonIcon()
    {
        if (muted == false)
        {
            soundButtonOn.SetActive(true);
            soundButtonOff.SetActive(false);
        }
        else
        {
            soundButtonOn.SetActive(false);
            soundButtonOff.SetActive(true);
        }
    }

    private void LoadAudioSettings()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }

    private void SaveAudioSettings()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0); // if "muted" = true, we will save it as "1", if false, we will save it as "0"
    }

    public void SoundOff()
    {
        muted = true;
        UpdateButtonIcon();
        SaveAudioSettings();
        audioManager.SetSoundSettings();
    }

    public void SoundOn()
    {
        muted = false;
        FindObjectOfType<AudioManager>().Play("AudioButtonClick");
        UpdateButtonIcon();
        SaveAudioSettings();
        audioManager.SetSoundSettings();
    }

    private void TriggerOnSoundMuteState_Event()
    {
        OptionsEvents.OnSoundMuteState?.Invoke(muted);
    }

}
