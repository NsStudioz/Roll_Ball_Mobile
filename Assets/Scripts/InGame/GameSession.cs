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
        Initialize();
    }

    private void Initialize()
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
        PlayerEvents.OnPlayerJump += CalculatePlayerJumps;
        PlayerEvents.OnJumpPickup += CalculatePlayerJumps;
        //
        PlayerEvents.OnKeyUsed += CalculateKeyCount;
        PlayerEvents.OnKeyPickup += CalculateKeyCount;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        //
        PlayerEvents.OnPlayerJump -= CalculatePlayerJumps;
        PlayerEvents.OnJumpPickup -= CalculatePlayerJumps;
        //
        PlayerEvents.OnKeyUsed -= CalculateKeyCount;
        PlayerEvents.OnKeyPickup -= CalculateKeyCount;

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
        PlayerEvents.OnPlayerJumpsCheck?.Invoke(PlayerJumps);
    }

    private void CalculatePlayerJumps(int jumps)
    {
        PlayerJumps += jumps;
        PlayerEvents.OnPlayerJumpsCheck?.Invoke(PlayerJumps);
    }

    private void ResetPlayerKeyCount()
    {
        if(KeyCount > 0)
            KeyCount = 0;
        PlayerEvents.OnKeyCountCheck?.Invoke(KeyCount);
    }

    private void CalculateKeyCount(int keys)
    {
        KeyCount += keys;
        PlayerEvents.OnKeyCountCheck?.Invoke(KeyCount);
    }

    private void SetTimerToLevel()
    {
        if (CurrentSceneIndex < 5) { EarlyLevels = true; }
        else { EarlyLevels = false; }
    }
}

/*    private void SyncSceneIndexToLevel()
    {
        CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Scene Index: " + CurrentSceneIndex);
    }*/

//PlayerEvents.OnLevelLoad += SyncSceneIndexToLevel;
//PlayerEvents.OnLevelLoad += SetTimerToLevel;
//PlayerEvents.OnLevelLoad += ResetPlayerJumps;
//PlayerEvents.OnLevelLoad += ResetPlayerKeyCount;
//

//PlayerEvents.OnLevelLoad -= SyncSceneIndexToLevel;
//PlayerEvents.OnLevelLoad -= SetTimerToLevel;
//PlayerEvents.OnLevelLoad -= ResetPlayerJumps;
//PlayerEvents.OnLevelLoad -= ResetPlayerKeyCount;

/*    void Update()
    {
        //CurrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }*/


/*    [SerializeField] private int currentSceneIndex;

    public int playerRemJumps; // player's remaining jumps.
    public int keyCount;
    //
    [SerializeField] private TMP_Text keysText;
    [SerializeField] private GameObject keysImageObject;
    [SerializeField] private TMP_Text jumpsText;
    [SerializeField] private GameObject keysTextObject;*/

//keysText.text = keyCount.ToString();
/*    public int GetPlayerRemainingJump()
    {
        return playerRemJumps;
    }*/

/*    public int GetPlayerKeyCount()
    {
        return keyCount;
    }*/

/*    public int GetSceneIndex()
    {
        return currentSceneIndex;
    }

    private void SetSceneIndex()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }*/


/*    public void SetTexts()
    {
        jumpsText.text = playerRemJumps.ToString();
        keysText.text = keyCount.ToString();
    }*/

/*    private void KeysObjectsAppearance()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex >= 32)
        {
            keysImageObject.SetActive(true);
            keysTextObject.SetActive(true);
        }
        else
        {
            keysImageObject.SetActive(false);
            keysTextObject.SetActive(false);
        }
    }*/

//InitOld();

/*    private void InitOld()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;

        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }*/


//jumpsText.text = playerRemJumps.ToString();
//keysText.text = keyCount.ToString();

/*    public void JumpsMinusOne()
{
    playerRemJumps--;
    jumpsText.text = playerRemJumps.ToString();
}*/

/*    public void AddToJumps(int jumpPickupsToAdd)
    {
        playerRemJumps += jumpPickupsToAdd;
        jumpsText.text = playerRemJumps.ToString();
    }*/


/*    public void AddToKeys(int keysToAdd)
    {
        keyCount = keyCount + keysToAdd;
        keysText.text = keyCount.ToString();
    }*/

/*    public void SubtractFromKeys(int keysToRemove)
    {
        keyCount = keyCount - keysToRemove;
        keysText.text = keyCount.ToString();
    }*/





