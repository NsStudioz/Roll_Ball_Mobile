using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{

    private void OnEnable()
    {
        OptionsEvents.OnSoundMute += OnMuteButtonsInvoked_PlayUnmuteSFX;
        OptionsEvents.OnMusicMute += OnMuteButtonsInvoked_PlayUnmuteSFX;
        //

    }



    private void OnDisable()
    {
        OptionsEvents.OnSoundMute -= OnMuteButtonsInvoked_PlayUnmuteSFX;
        OptionsEvents.OnMusicMute -= OnMuteButtonsInvoked_PlayUnmuteSFX;
        //

    }

    private void OnMuteButtonsInvoked_PlayUnmuteSFX()
    {
        SoundManager.Instance.Play("AudioButtonClick");
    }

    private void Play_()
    {
        SoundManager.Instance.Play("");
    }

    #region Player_Functions

    private void Play_PlayerJump()
    {
        SoundManager.Instance.Play("");
    }


    #endregion


}
