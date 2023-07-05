using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents
{

    #region PlayerJump_Events

    public delegate void PlayerJump(int jumps);
    public static PlayerJump OnPlayerJump;

    public delegate void JumpPickup(int keys);
    public static JumpPickup OnJumpPickup;

    public delegate void PlayerJumpsCheck(int playerJumps);
    public static PlayerJumpsCheck OnPlayerJumpsCheck;

    #endregion


    #region PlayerKey_Events

    public delegate void KeyPickup(int keys);
    public static KeyPickup OnKeyPickup;

    public delegate void KeyCountCheck(int keys);
    public static KeyCountCheck OnKeyCountCheck;

    public delegate void KeyUsed(int keys);
    public static KeyUsed OnKeyUsed;

    #endregion


    #region Timer_Events:

    public delegate void OutOfTime();
    public static OutOfTime OnOutOfTime;

    public delegate void TimePickup(float time);
    public static TimePickup OnTimePickup;

    public delegate void TriggerStopTimer();
    public static TriggerStopTimer OnTriggerStopTimer;

    #endregion


    #region Level_Events:

    public delegate void LevelSelected(int currentLevelIndex);
    public static LevelSelected OnLevelSelected;

    public delegate void LevelStarted();
    public static LevelStarted OnLevelStarted;

    public delegate void LevelCompleted();
    public static LevelCompleted OnLevelCompleted;

    public delegate void PlayerDead();
    public static PlayerDead OnPlayerDead;

    public delegate void RestartLevel(int currentLevelIndex);
    public static RestartLevel OnRestartLevel;

    public delegate void LevelRestarted();
    public static LevelRestarted OnLevelRestarted;

    public delegate void ReturnToMainMenu();
    public static ReturnToMainMenu OnReturnToMainMenu;

    #endregion

}

