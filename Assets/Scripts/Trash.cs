using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash
{
    #region ---------------------------------------------------MusicManager---------------------------------------------------
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


    #endregion

    #region ---------------------------------------------------AudioManager---------------------------------------------------

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

    #endregion

    #region ---------------------------------------------------Player---------------------------------------------------

    /*    private bool GetIngameScenesIndex()
    {
        return GameSession.Instance.CurrentSceneIndex > 2 && GameSession.Instance.CurrentSceneIndex < 53;
    }*/

    #endregion

    #region ---------------------------------------------------PersistentPlayerSpawner---------------------------------------------------

    /*        if (persistentPlayerPrefab != null && persistentInstance == null)
        {
            GameObject persistentObject = Instantiate(persistentPlayerPrefab);
            persistentInstance = persistentObject;
            DontDestroyOnLoad(persistentObject);
        }*/

    #endregion


    #region---------------------------------------------------SoundSettings---------------------------------------------------


    /*    public static SoundSettings soundSettings;
[SerializeField] GameObject soundButtonOn;
[SerializeField] GameObject soundButtonOff;*/

    /*    AudioManager audioManager;

        private void Awake()
        {
            GameObject forAudioManager = GameObject.Find("AudioManager");
            audioManager = forAudioManager.GetComponent<AudioManager>();
        }*/

    /*    public void UpdateButtonIcon()
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
        }*/

    /*    public void SoundOff()
        {
            UpdateButtonIcon();
            muted = true;
            SaveAudioSettings();
            audioManager.OnSoundMuteStateInvoked_SetSoundSettings();
        }*/

    /*    public void SoundOn()
        {
            muted = false;
            UpdateButtonIcon();
            SaveAudioSettings();
            audioManager.OnSoundMuteStateInvoked_SetSoundSettings();
        }*/

    //UpdateButtonIcon();

    #endregion


    #region---------------------------------------------------MusicSettings---------------------------------------------------
    /*    MusicManager musicManager;

    [SerializeField] GameObject musicButtonOn;
    [SerializeField] GameObject musicButtonOff;*/

    //
    /*    private void Awake()
        {
            GameObject forMusicManager = GameObject.Find("MusicManager");
            musicManager = forMusicManager.GetComponent<MusicManager>();
        }*/


    //UpdateButtonIcon();


    /*    public void MusicOn()
        {
            m_Muted = false;
            FindObjectOfType<AudioManager>().Play("AudioButtonClick");
            UpdateButtonIcon();
            SaveMusicSettings();
            musicManager.SetMusicSettings();
        }*/

    /*    public void MusicOff()
        {
            m_Muted = true;
            UpdateButtonIcon();
            SaveMusicSettings();
            musicManager.SetMusicSettings();
        }*/

    /*    private void UpdateButtonIcon()
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
        }*/

    #endregion











}
