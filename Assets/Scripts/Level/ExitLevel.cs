using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{

    private readonly string player = "Player";
    private int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = GameSession.Instance.CurrentSceneIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEvents.OnTriggerStopTimer?.Invoke();

        if (other.CompareTag(player))
            CheckLevelProgress();
    }

    private void CheckLevelProgress()
    {
        if (GameSession.Instance.CurrentSceneIndex == 52)
            TriggerOnReturnToMainMenuEvent();
        else
        {
            TriggerOnLevelCompletedEvent();
            SaveLevelProgress();
        }
    }

    private void TriggerOnReturnToMainMenuEvent()
    {
        GameEvents.OnReturnToMainMenu?.Invoke();
    }

    private void TriggerOnLevelCompletedEvent()
    {
        GameEvents.OnLevelCompleted?.Invoke();
    }


    // Setting Int as Index (This will make level selection buttons interactable)
    private void SaveLevelProgress()
    {  
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt")) 
            PlayerPrefs.SetInt("levelAt", nextSceneLoad); 
    }
}

