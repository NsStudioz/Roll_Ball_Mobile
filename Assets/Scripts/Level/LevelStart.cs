using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{

/*    TimerScript timerScript;

    void Start()
    {
        GameObject timesUp = GameObject.Find("Gamesession");
        timerScript = timesUp.GetComponent<TimerScript>();
    }*/

    private void OnTriggerExit2D(Collider2D player)
    {
        //timerScript.startTimer = true;
        PlayerEvents.OnLevelStarted?.Invoke();
    }

}
