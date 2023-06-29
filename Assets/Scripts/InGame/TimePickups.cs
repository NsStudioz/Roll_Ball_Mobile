using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickups : MonoBehaviour
{

    [SerializeField] float timeToAdd = 1f;

    TimerScript timerScript;

    void Start()
    {
        GameObject myTimerScript = GameObject.Find("Gamesession");
        timerScript = myTimerScript.GetComponent<TimerScript>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(tag == "TimePlusOne")
        {
            timerScript.AddTime(timeToAdd);
        }

        if (tag == "TimePlusTwo")
        {
            timerScript.AddTime(timeToAdd + 1f);
        }
        if (tag == "TimePlusThree")
        {
            timerScript.AddTime(timeToAdd + 2f);
        }
        if (tag == "TimePlusFour")
        {
            timerScript.AddTime(timeToAdd + 3f);
        }
        if (tag == "TimePlusFive")
        {
            timerScript.AddTime(timeToAdd + 4f);
        }

        FindObjectOfType<AudioManager>().Play("TimePickup");
        Destroy(gameObject);
    }
}
