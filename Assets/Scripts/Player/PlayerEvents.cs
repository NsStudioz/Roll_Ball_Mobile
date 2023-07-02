using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{

    public delegate void LevelStarted();
    public static LevelStarted OnLevelStarted;

    public delegate void LevelCompleted();
    public static LevelCompleted OnLevelCompleted;

    public delegate void LevelReset();
    public static LevelReset OnLevelReset;

    public delegate void OutOfTime();
    public static OutOfTime OnOutOfTime;

    public delegate void PlayerDead();
    public static PlayerDead OnPlayerDead;

    public delegate void GamePause();
    public static GamePause OnGamePause;

    public delegate void GameResume();
    public static GameResume OnGameResume;

/*    public delegate void LevelLoad();
    public static LevelLoad OnLevelLoad;
*/
    public delegate void TriggerStopTimer();
    public static TriggerStopTimer OnTriggerStopTimer;

    public delegate void PlayerJumpsCheck(int playerJumps);
    public static PlayerJumpsCheck OnPlayerJumpsCheck;
    //
    public delegate void KeyPickup(int keys);
    public static KeyPickup OnKeyPickup;

    public delegate void KeyCountCheck(int keys);
    public static KeyCountCheck OnKeyCountCheck;

    public delegate void KeyUsed(int keys);
    public static KeyUsed OnKeyUsed;

    public delegate void PlayerJump(int jumps);
    public static PlayerJump OnPlayerJump;

    public delegate void JumpPickup(int keys);
    public static JumpPickup OnJumpPickup;

    public delegate void TimePickup(float time);
    public static TimePickup OnTimePickup;




}
