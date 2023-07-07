using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{

    private string player = "Player";
    private int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = GameSession.Instance.CurrentSceneIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameEvents.OnTriggerStopTimer?.Invoke();
        SoundManager.Instance.Play("LevelCompleted");

        if (other.CompareTag(player))
            CheckLevelProgress();
    }

    private void CheckLevelProgress()
    {
        if (GameSession.Instance.CurrentSceneIndex == 52)
            GameEvents.OnReturnToMainMenu?.Invoke();
        else
        {
            GameEvents.OnLevelCompleted?.Invoke();   
            SaveLevelProgress();
        }
    }

    // Setting Int for Index
    private void SaveLevelProgress()
    {  
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt")) 
            PlayerPrefs.SetInt("levelAt", nextSceneLoad); 
    }
}

