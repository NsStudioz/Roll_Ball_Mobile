using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{

    LevelChanger_Levels levelChangerOfLevels;

    [SerializeField] private bool adTestMode = true;

    public static AdManager Instance; // making this script a singleton by creating a variable of the same type as this class.

    private string gameId = "4709555";


    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, adTestMode);
        }
    }

    // Check for needed changes
    public void ShowAd(LevelChanger_Levels levelChangerOfLevels)
    {
        this.levelChangerOfLevels = levelChangerOfLevels;

        Advertisement.Show("InterstitialVideo");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                // IMPORTANT;
                // CLEAR THE COMMENT AFTER GAME IS FULLY RELEASED TO GOOGLE:
                //levelChangerOfLevels.ContinueGame();
                Debug.Log("Ad has finished");
                break;
            case ShowResult.Skipped:
                Debug.Log("Ad has been skipped");
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready");
    }
}
