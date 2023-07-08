using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersistentPlayerSpawner : MonoBehaviour
{

    public static PersistentPlayerSpawner Instance;

    [SerializeField] GameObject persistentPlayerPrefab = null;
    [SerializeField] GameObject persistentInstance = null;

    private static bool hasSpawned = false;

    private void Awake()
    {
        InitializeSingleton();

        if (hasSpawned) return;

        SpawnPersistentPlayerObject();

        hasSpawned = true;
    }
    private void InitializeSingleton()
    {
        if (Instance == null)  // singleton pattern
            Instance = this;
        else
        {
            Destroy(gameObject);
            return; // so that no more code is called before we destroy this gameObject.
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene sceneIndex, LoadSceneMode mode)
    {
        SetPlayerObjectVisibility();
    }

    private void SpawnPersistentPlayerObject()
    {
        if (persistentInstance == null)
        {
            GameObject persistentObject = Instantiate(persistentPlayerPrefab);
            persistentInstance = persistentObject;
            DontDestroyOnLoad(persistentObject);
        }

        SetPlayerObjectVisibility();
    }

    private void SetPlayerObjectVisibility()
    {
        if (persistentPlayerPrefab == null)
            return;

        if (GameSession.Instance.CurrentSceneIndex > 2 && GameSession.Instance.CurrentSceneIndex < 53)
            persistentInstance.SetActive(true);
        else
            persistentInstance.SetActive(false);
    }

}
