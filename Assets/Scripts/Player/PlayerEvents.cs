using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEvents
{

    public delegate void PlayerJump();
    public static PlayerJump OnPlayerJump;

    public delegate void PlayerDead();
    public static PlayerDead OnPlayerDead;

    public delegate void LevelCompleted();
    public static LevelCompleted OnLevelCompleted;

    public delegate void TimeOut();
    public static TimeOut OnTimeOut;

/*    public delegate void PlayerDead();
    public static PlayerDead OnPlayerDead;

    public delegate void PlayerDead();
    public static PlayerDead OnPlayerDead;*/


}
