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
        OptionsEvents.OnButtonClicked += OnButtonClickedInvoked_PlayButtonClickSFX;
        OptionsEvents.OnBackButtonClicked += OnBackButtonClickedInvoked_PlayBackButtonClickSFX;
        OptionsEvents.OnPause += OnPauseInvoked_PlayPauseSFX;
        OptionsEvents.OnResume += OnResumeInvoked_PlayResumeSFX;
        //
        GameEvents.OnLevelSelected += OnLevelSelectedInvoked_PlayLevelSelectedSFX;
        GameEvents.OnLevelCompleted += OnLevelCompleted_PlayLevelCompletedSFX;
        GameEvents.OnReturnToMainMenu += OnReturnToMainMenuInvoked_PlayReturnToMainMenuSFX;
        GameEvents.OnRestartLevel += OnRestartLevelInvoked_PlayRestartLevelSFX;
        GameEvents.OnLevelRestarted += OnLevelRestartedInvoked_PlayLevelRestartedSFX;
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
        OptionsEvents.OnButtonClicked -= OnButtonClickedInvoked_PlayButtonClickSFX;
        OptionsEvents.OnBackButtonClicked -= OnBackButtonClickedInvoked_PlayBackButtonClickSFX;
        OptionsEvents.OnPause -= OnPauseInvoked_PlayPauseSFX;
        OptionsEvents.OnResume -= OnResumeInvoked_PlayResumeSFX;
        //
        GameEvents.OnLevelSelected -= OnLevelSelectedInvoked_PlayLevelSelectedSFX;
        GameEvents.OnLevelCompleted -= OnLevelCompleted_PlayLevelCompletedSFX;
        GameEvents.OnRestartLevel -= OnRestartLevelInvoked_PlayRestartLevelSFX;
        GameEvents.OnReturnToMainMenu -= OnReturnToMainMenuInvoked_PlayReturnToMainMenuSFX;
        GameEvents.OnLevelRestarted -= OnLevelRestartedInvoked_PlayLevelRestartedSFX;
        //
        GameEvents.OnOutOfTime -= OnOutOfTimeOrOnPlayerDeadInvoked_PlayOutOfTimeSFX;
        GameEvents.OnPlayerDead -= OnOutOfTimeOrOnPlayerDeadInvoked_PlayOutOfTimeSFX;
        GameEvents.OnPlayerJump -= OnPlayerJumpInvoked_PlayPlayerJumpSFX;
        //
        GameEvents.OnJumpPickup -= OnJumpPickupInvoked_PlayJumpPickupSFX;
        GameEvents.OnTimePickup -= OnTimePickupInvoked_PlayTimePickupSFX;
        GameEvents.OnKeyPickup -= OnKeyPickupInvoked_PlayKeyPickupSFX;
        GameEvents.OnKeyUsed -= OnKeyUsedInvoked_PlayKeyUsedSFX;
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

    private void OnButtonClickedInvoked_PlayButtonClickSFX()
    {
        SoundManager.Instance.Play("ButtonClick");
    }

    private void OnBackButtonClickedInvoked_PlayBackButtonClickSFX()
    {
        SoundManager.Instance.Play("BackButtonClick");
    }

    private void OnLevelSelectedInvoked_PlayLevelSelectedSFX(int currentLevelIndex)
    {
        SoundManager.Instance.Play("LevelChoosed");
    }

    private void OnReturnToMainMenuInvoked_PlayReturnToMainMenuSFX()
    {
        SoundManager.Instance.Play("ButtonClick");
    }

    private void OnRestartLevelInvoked_PlayRestartLevelSFX(int currentLevelIndex)
    {
        SoundManager.Instance.Play("ButtonClick");
    }

    private void OnLevelCompleted_PlayLevelCompletedSFX()
    {
        SoundManager.Instance.Play("LevelCompleted");
    }

    private void OnLevelRestartedInvoked_PlayLevelRestartedSFX()
    {
        SoundManager.Instance.Play("ButtonClick");
    }

    private void OnPauseInvoked_PlayPauseSFX()
    {
        SoundManager.Instance.Play("MenuButtonClick");
    }

    private void OnResumeInvoked_PlayResumeSFX()
    {
        SoundManager.Instance.Play("ButtonClick");
    }

    #endregion


}
