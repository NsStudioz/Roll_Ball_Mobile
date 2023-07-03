using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameSession : MonoBehaviour
{

    public static GameSession Instance;

    public bool EarlyLevels { get; private set; }  // timer completely disabled during the first few levels.
    public int CurrentSceneIndex { get; private set; }

    public int PlayerJumps { get; private set; }

    public int KeyCount { get; private set; }

    private void Awake()
    {
        InitializeSingleton();
    }

    private void InitializeSingleton()
    {
        if (Instance == null) { Instance = this; } // singleton pattern
        else
        {
            Destroy(gameObject);
            return; // so that no more code is called before we destroy this gameObject.
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        //
        GameEvents.OnPlayerJump += CalculatePlayerJumps;
        GameEvents.OnJumpPickup += CalculatePlayerJumps;
        //
        GameEvents.OnKeyUsed += CalculateKeyCount;
        GameEvents.OnKeyPickup += CalculateKeyCount;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //
        GameEvents.OnPlayerJump -= CalculatePlayerJumps;
        GameEvents.OnJumpPickup -= CalculatePlayerJumps;
        //
        GameEvents.OnKeyUsed -= CalculateKeyCount;
        GameEvents.OnKeyPickup -= CalculateKeyCount;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CurrentSceneIndex = scene.buildIndex;
        Debug.Log("Scene Index: " + CurrentSceneIndex);

        if (scene.buildIndex > 2 && scene.buildIndex < 53)
            ResetJumpsAndKeysAndTimer();
    }

    private void ResetJumpsAndKeysAndTimer()
    {
        SetTimerToLevel();
        ResetPlayerJumps();
        ResetPlayerKeyCount();
    }

    private void ResetPlayerJumps()
    {
        PlayerJumps = 3;
        GameEvents.OnPlayerJumpsCheck?.Invoke(PlayerJumps);
    }

    private void CalculatePlayerJumps(int jumps)
    {
        PlayerJumps += jumps;
        GameEvents.OnPlayerJumpsCheck?.Invoke(PlayerJumps);
    }

    private void ResetPlayerKeyCount()
    {
        if (KeyCount > 0) { KeyCount = 0; }
        GameEvents.OnKeyCountCheck?.Invoke(KeyCount);
    }

    private void CalculateKeyCount(int keys)
    {
        KeyCount += keys;
        GameEvents.OnKeyCountCheck?.Invoke(KeyCount);
    }

    private void SetTimerToLevel()
    {
        if (CurrentSceneIndex < 5) { EarlyLevels = true; }
        else { EarlyLevels = false; }
    }
}