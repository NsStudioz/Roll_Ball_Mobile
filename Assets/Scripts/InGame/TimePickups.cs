using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickups : MonoBehaviour
{

    [SerializeField] private float TimePlusOne =   1f;
    [SerializeField] private float TimePlusTwo =   2f;
    [SerializeField] private float TimePlusThree = 3f;
    [SerializeField] private float TimePlusFour =  4f;
    [SerializeField] private float TimePlusFive =  5f;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(tag == "TimePlusOne")
            GameEvents.OnTimePickup?.Invoke(TimePlusOne);
        if (tag == "TimePlusTwo")
            GameEvents.OnTimePickup?.Invoke(TimePlusTwo);
        if (tag == "TimePlusThree")
            GameEvents.OnTimePickup?.Invoke(TimePlusThree);
        if (tag == "TimePlusFour")
            GameEvents.OnTimePickup?.Invoke(TimePlusFour);
        if (tag == "TimePlusFive")
            GameEvents.OnTimePickup?.Invoke(TimePlusFive);

        AudioManager.Instance.Play("TimePickup");
        Destroy(gameObject);
    }

}

//[SerializeField] private float timeToAdd = 1f;

/*    TimerScript timerScript;

    void Start()
    {
        GameObject myTimerScript = GameObject.Find("Gamesession");
        timerScript = myTimerScript.GetComponent<TimerScript>();
    }*/

/*private void OnTriggerEnter2D(Collider2D player)
{
    if (tag == "TimePlusOne")
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

    //FindObjectOfType<AudioManager>().Play("TimePickup");
    AudioManager.Instance.Play("TimePickup");
    Destroy(gameObject);
}*/
