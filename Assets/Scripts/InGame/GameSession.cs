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

    private void Awake() => InitializeSingleton();

    private void InitializeSingleton()
    {
        if (Instance == null) // singleton pattern
            Instance = this;
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
        GameEvents.OnPlayerJump += OnPlayerJumpOrOnJumpPickupInvoked_CalculatePlayerJumps;
        GameEvents.OnJumpPickup += OnPlayerJumpOrOnJumpPickupInvoked_CalculatePlayerJumps;
        //
        GameEvents.OnKeyUsed += OnKeyPickupOrOnKeyUsedInvoked_CalculateKeyCount;
        GameEvents.OnKeyPickup += OnKeyPickupOrOnKeyUsedInvoked_CalculateKeyCount;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //
        GameEvents.OnPlayerJump -= OnPlayerJumpOrOnJumpPickupInvoked_CalculatePlayerJumps;
        GameEvents.OnJumpPickup -= OnPlayerJumpOrOnJumpPickupInvoked_CalculatePlayerJumps;
        //
        GameEvents.OnKeyUsed -= OnKeyPickupOrOnKeyUsedInvoked_CalculateKeyCount;
        GameEvents.OnKeyPickup -= OnKeyPickupOrOnKeyUsedInvoked_CalculateKeyCount;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CurrentSceneIndex = scene.buildIndex;
#if UNITY_EDITOR
        Debug.Log("Scene Index: " + CurrentSceneIndex);
#endif

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
        TriggerOnPlayerJumpsCheckEvent();
    }

    private void OnPlayerJumpOrOnJumpPickupInvoked_CalculatePlayerJumps(int jumps)
    {
        PlayerJumps += jumps;
        TriggerOnPlayerJumpsCheckEvent();
    }

    private void TriggerOnPlayerJumpsCheckEvent()
    {
        GameEvents.OnPlayerJumpsCheck?.Invoke(PlayerJumps);
    }


    private void ResetPlayerKeyCount()
    {
        if (KeyCount > 0) { KeyCount = 0; }
        TriggerOnKeyCountCheckEvent();
    }

    private void OnKeyPickupOrOnKeyUsedInvoked_CalculateKeyCount(int keys)
    {
        KeyCount += keys;
        TriggerOnKeyCountCheckEvent();
    }

    private void TriggerOnKeyCountCheckEvent()
    {
        GameEvents.OnKeyCountCheck?.Invoke(KeyCount);
    }

    private void SetTimerToLevel()
    {
        if (CurrentSceneIndex < 6) { EarlyLevels = true; }
        else { EarlyLevels = false; }
    }
}