using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickups : MonoBehaviour
{

    public float timeToAdd = 1f;

    TimerScript timerScript;

    void Start()
    {
        GameObject myTimerScript = GameObject.Find("Gamesession");
        timerScript = myTimerScript.GetComponent<TimerScript>();
    }

    public void OnTriggerEnter2D(Collider2D player)
    {
        if(tag == "TimePlusOne")
        {
            // FindObjectOfType<TimerScript>().AddTime(timeToAdd);
            timerScript.AddTime(timeToAdd);
        }

        if (tag == "TimePlusTwo")
        {
            // FindObjectOfType<TimerScript>().AddTime(timeToAdd + 1f);
            timerScript.AddTime(timeToAdd + 1f);
        }
        if (tag == "TimePlusThree")
        {
            // FindObjectOfType<TimerScript>().AddTime(timeToAdd + 2f);
            timerScript.AddTime(timeToAdd + 2f);
        }
        if (tag == "TimePlusFour")
        {
            // FindObjectOfType<TimerScript>().AddTime(timeToAdd + 3f);
            timerScript.AddTime(timeToAdd + 3f);
        }
        if (tag == "TimePlusFive")
        {
            // FindObjectOfType<TimerScript>().AddTime(timeToAdd + 4f);
            timerScript.AddTime(timeToAdd + 4f);
        }

        FindObjectOfType<AudioManager>().Play("TimePickup");
        Destroy(gameObject);
    }
}
