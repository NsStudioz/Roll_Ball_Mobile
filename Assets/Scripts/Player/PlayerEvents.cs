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
    //
    public delegate void KeyPickup();
    public static KeyPickup OnKeyPickup;

    public delegate void KeyUsed();
    public static KeyUsed OnKeyUsed;

    public delegate void PlayerJump();
    public static PlayerJump OnPlayerJump;

    public delegate void JumpPickup();
    public static JumpPickup OnJumpPickup;

    public delegate void TimePickup(float time);
    public static TimePickup OnTimePickup;




}
