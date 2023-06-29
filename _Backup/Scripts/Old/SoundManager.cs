using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundSettings soundSettings;
    public GameObject soundButtonOn;
    public GameObject soundButtonOff;
    public bool muted = false;

    /*void Awake()
    {
        if(soundSettings == null)
        {
            soundSettings = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }*/

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

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            // Audio off
        }
        else
        {
            muted = false;
            // Audio on
        }

        SaveAudioSettings();
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
/*        soundButtonOn.SetActive(false);
        soundButtonOff.SetActive(true);*/
        muted = true;
        SaveAudioSettings();
        UpdateButtonIcon();
        //
        FindObjectOfType<AudioManager>().Play("AudioButtonClick");
        FindObjectOfType<AudioManager>().Mute("PlayerJump");
        FindObjectOfType<AudioManager>().Mute("PlayerHit");
        FindObjectOfType<AudioManager>().Mute("PlayerDeath");
        FindObjectOfType<AudioManager>().Mute("PlayerSound4");
        FindObjectOfType<AudioManager>().Mute("ButtonClick");
        FindObjectOfType<AudioManager>().Mute("AudioButtonClick");
        FindObjectOfType<AudioManager>().Mute("LevelChoosed");
        FindObjectOfType<AudioManager>().Mute("Timer");
        FindObjectOfType<AudioManager>().Mute("JumpsPickup");
        FindObjectOfType<AudioManager>().Mute("TimePickup");
        FindObjectOfType<AudioManager>().Mute("LevelCompleted");
        FindObjectOfType<AudioManager>().Mute("BackButtonClick");
        FindObjectOfType<AudioManager>().Mute("MenuButtonClick");
    }

    public void SoundOn()
    {
/*        soundButtonOn.SetActive(true);
        soundButtonOff.SetActive(false);*/
        muted = false;
        SaveAudioSettings();
        UpdateButtonIcon();
        //

        FindObjectOfType<AudioManager>().Play("AudioButtonClick");
        FindObjectOfType<AudioManager>().Unmute("PlayerJump");
        FindObjectOfType<AudioManager>().Unmute("PlayerHit");
        FindObjectOfType<AudioManager>().Unmute("PlayerDeath");
        FindObjectOfType<AudioManager>().Unmute("PlayerSound4");
        FindObjectOfType<AudioManager>().Unmute("ButtonClick");
        FindObjectOfType<AudioManager>().Unmute("AudioButtonClick");
        FindObjectOfType<AudioManager>().Unmute("LevelChoosed");
        FindObjectOfType<AudioManager>().Unmute("Timer");
        FindObjectOfType<AudioManager>().Unmute("JumpsPickup");
        FindObjectOfType<AudioManager>().Unmute("TimePickup");
        FindObjectOfType<AudioManager>().Unmute("LevelCompleted");
        FindObjectOfType<AudioManager>().Unmute("BackButtonClick");
        FindObjectOfType<AudioManager>().Unmute("MenuButtonClick");
    }
}
