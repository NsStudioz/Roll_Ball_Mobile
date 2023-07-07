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
        GameEvents.OnOutOfTime += OnOutOfTimeOrOnPlayerDeadInvoked_PlayOutOfTimeSFX;
        GameEvents.OnPlayerDead += OnOutOfTimeOrOnPlayerDeadInvoked_PlayOutOfTimeSFX;
        GameEvents.OnPlayerJump += OnPlayerJumpInvoked_PlayPlayerJumpSFX;
        //
        GameEvents.OnJumpPickup += OnJumpPickupInvoked_PlayJumpPickupSFX;
        GameEvents.OnTimePickup += OnTimePickupInvoked_PlayTimePickupSFX;
        GameEvents.OnKeyPickup += OnKeyPickupInvoked_PlayKeyPickupSFX;
        GameEvents.OnKeyUsed += OnKeyUsedInvoked_PlayKeyUsedSFX;
    }

    private void OnDisable()
    {
        OptionsEvents.OnSoundMute -= OnMuteButtonsInvoked_PlayUnmuteSFX;
        OptionsEvents.OnMusicMute -= OnMuteButtonsInvoked_PlayUnmuteSFX;
        //
        GameEvents.OnOutOfTime -= OnOutOfTimeOrOnPlayerDeadInvoked_PlayOutOfTimeSFX;
        GameEvents.OnPlayerDead -= OnOutOfTimeOrOnPlayerDeadInvoked_PlayOutOfTimeSFX;
        //
        GameEvents.OnJumpPickup -= OnJumpPickupInvoked_PlayJumpPickupSFX;
        GameEvents.OnTimePickup -= OnTimePickupInvoked_PlayTimePickupSFX;
        GameEvents.OnKeyPickup -= OnKeyPickupInvoked_PlayKeyPickupSFX;
        GameEvents.OnKeyUsed -= OnKeyUsedInvoked_PlayKeyUsedSFX;
    }


    private void OnBla_Invoked_Play_Bla()
    {

    }



    #region Player_Functions
    private void OnMuteButtonsInvoked_PlayUnmuteSFX()
    {
        SoundManager.Instance.Play("AudioButtonClick");
    }

    private void OnOutOfTimeOrOnPlayerDeadInvoked_PlayOutOfTimeSFX()
    {
        SoundManager.Instance.Play("PlayerDeath");
    }

    private void OnPlayerJumpInvoked_PlayPlayerJumpSFX(int jumps)
    {
        SoundManager.Instance.Play("PlayerJump");
    }
    private void OnJumpPickupInvoked_PlayJumpPickupSFX(int jumps)
    {
        SoundManager.Instance.Play("JumpsPickup");
    }

    private void OnTimePickupInvoked_PlayTimePickupSFX(float time)
    {
        SoundManager.Instance.Play("TimePickup");
    }

    private void OnKeyPickupInvoked_PlayKeyPickupSFX(int key)
    {
        SoundManager.Instance.Play("KeyPickup");
    }

    private void OnKeyUsedInvoked_PlayKeyUsedSFX(int key)
    {
        SoundManager.Instance.Play("BlockUnlock");
    }


    #endregion


}
