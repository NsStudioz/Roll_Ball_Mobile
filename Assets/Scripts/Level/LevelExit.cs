using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{

    TimerScript timerScript;
    MusicManager musicManager;

    [SerializeField] int currentSceneIndex;

    private int[] musicTriggerValues = { 12, 17, 22, 27, 31, 34, 39, 42, 49, 51 };

    void Start()
    {
        GameObject thisGameSession = GameObject.Find("Gamesession");
        timerScript = thisGameSession.GetComponent<TimerScript>();
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        timerScript.startTimer = false;

        if (musicTriggerValues.Contains(currentSceneIndex))
        {
            musicManager.stateSwitch = false;
        }
        
        if(currentSceneIndex == 52)
        {
            musicManager.SwapTracks("Theme_50", "Theme_Main_Menu");
        }
    }
}
