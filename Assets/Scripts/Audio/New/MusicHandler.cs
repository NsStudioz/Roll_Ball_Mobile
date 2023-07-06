using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicHandler : MonoBehaviour
{
    public static event Action<string, string> OnTriggerSwapTracks;

    private string[] totalTracksIndexers = new string[12] { "Theme_Main_Menu", "Theme_1_10", "Theme_11_15", "Theme_16_20",
                                                            "Theme_21_25", "Theme_26_29", "Theme_30_32", "Theme_33_37",
                                                            "Theme_38_40", "Theme_41_47", "Theme_48_49", "Theme_50" };

    private void Start()
    {
        GameEvents.OnLevelSelected += OnLevelSelected_CountDownTimerToSwapTracks;
        GameEvents.OnLevelCompleted += OnLevelCompleted_CountDownTimerToSwapTracks;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelSelected -= OnLevelSelected_CountDownTimerToSwapTracks;
        GameEvents.OnLevelCompleted -= OnLevelCompleted_CountDownTimerToSwapTracks;
    }


    #region Helpers

    private void TriggerSwapTrackEvent(string oldTrack, string newTrack)
    {
        OnTriggerSwapTracks?.Invoke(oldTrack, newTrack);
    }

    private bool CheckCurrentSceneIndex(int selectedSceneIndex, int lessThan, int greaterThan)
    {
        return selectedSceneIndex >= lessThan && selectedSceneIndex <= greaterThan;
    }

    #endregion

    private void OnLevelSelected_CountDownTimerToSwapTracks(int selectedSceneIndex)
    {
        StartCoroutine(OnLevelSelectedCountDownTimer(selectedSceneIndex));
    }
    private void OnLevelCompleted_CountDownTimerToSwapTracks()
    {
        StartCoroutine(OnLevelCompletedCountDownTimer());
    }

    private IEnumerator OnLevelSelectedCountDownTimer(int selectedSceneIndex)
    {
        yield return new WaitForSeconds(1);
        OnLevelSelected_SwapTracks(selectedSceneIndex);
    }
    private IEnumerator OnLevelCompletedCountDownTimer()
    {
        yield return new WaitForSeconds(1.2f);
        OnLevelCompleted_SwapTracks();
    }

    private void OnLevelSelected_SwapTracks(int selectedSceneIndex)
    {
        if (CheckCurrentSceneIndex(selectedSceneIndex, 3, 12))                      // selectedSceneIndex >= 3 && selectedSceneIndex <= 12
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[1]);  // index 0 => index 1;

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 13, 17))                // selectedSceneIndex >= 13 && selectedSceneIndex <= 17
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[2]);  // index 0 => index 2

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 18, 22))                // selectedSceneIndex >= 18 && selectedSceneIndex <= 22
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[3]);  // index 0 => index 3;

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 23, 27))                // selectedSceneIndex >= 23 && selectedSceneIndex <= 27
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[4]);  // index 0 => index 4;

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 28, 31))                // selectedSceneIndex >= 28 && selectedSceneIndex <= 31
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[5]);  // index 0 => index 5;

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 32, 34))                // selectedSceneIndex >= 32 && selectedSceneIndex <= 34
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[6]);  // index 0 => index 6;

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 35, 39))                // selectedSceneIndex >= 35 && selectedSceneIndex <= 39
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[7]);  // index 0 => index 7;

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 40, 42))                // selectedSceneIndex >= 40 && selectedSceneIndex <= 42
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[8]);  // index 0 => index 8;

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 43, 49))                // selectedSceneIndex >= 43 && selectedSceneIndex <= 49
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[9]);  // index 0 => index 9;

        else if (CheckCurrentSceneIndex(selectedSceneIndex, 50, 51))                // selectedSceneIndex >= 50 && selectedSceneIndex <= 51
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[10]); // index 0 => index 10;

        else if (selectedSceneIndex == 52)
            TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[11]); // index 0 => index 11;
        else
        {
            Debug.Log("Something went wrong, please check!");
            //musicManager.Play("Theme_Main_Menu");
        }
    }

    private void OnLevelCompleted_SwapTracks()
    {
        int sceneIndex = GameSession.Instance.CurrentSceneIndex;

        switch (sceneIndex)
        {
            case 3:
                TriggerSwapTrackEvent(totalTracksIndexers[0], totalTracksIndexers[1]);
                break;
            case 13:
                TriggerSwapTrackEvent(totalTracksIndexers[1], totalTracksIndexers[2]);
                break;
            case 18:
                TriggerSwapTrackEvent(totalTracksIndexers[2], totalTracksIndexers[3]);
                break;
            case 23:
                TriggerSwapTrackEvent(totalTracksIndexers[3], totalTracksIndexers[4]);
                break;
            case 28:
                TriggerSwapTrackEvent(totalTracksIndexers[4], totalTracksIndexers[5]);
                break;
            case 32:
                TriggerSwapTrackEvent(totalTracksIndexers[5], totalTracksIndexers[6]);
                break;
            case 35:
                TriggerSwapTrackEvent(totalTracksIndexers[6], totalTracksIndexers[7]);
                break;
            case 40:
                TriggerSwapTrackEvent(totalTracksIndexers[7], totalTracksIndexers[8]);
                break;
            case 43:
                TriggerSwapTrackEvent(totalTracksIndexers[8], totalTracksIndexers[9]);
                break;
            case 50:
                TriggerSwapTrackEvent(totalTracksIndexers[9], totalTracksIndexers[10]);
                break;
            case 52:
                TriggerSwapTrackEvent(totalTracksIndexers[10], totalTracksIndexers[11]);
                break;
            default:
                break;
        }
    }

}
