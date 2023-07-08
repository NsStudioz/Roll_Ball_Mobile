using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickups : MonoBehaviour
{

    [SerializeField] private float timeToAdd;
    private readonly string Player = "Player";
    //
    private readonly string TimePlusOne = "TimePlusOne";
    private readonly string TimePlusTwo = "TimePlusTwo";
    private readonly string TimePlusThree = "TimePlusThree";
    private readonly string TimePlusFour = "TimePlusFour";
    private readonly string TimePlusFive = "TimePlusFive";

    private void Start() => InitializeValue();

    private void InitializeValue()
    {
        if (CompareTag(TimePlusOne))
            timeToAdd = 1f;
        else if (CompareTag(TimePlusTwo))
            timeToAdd = 2f;
        else if (CompareTag(TimePlusThree))
            timeToAdd = 3f;
        else if (CompareTag(TimePlusFour))
            timeToAdd = 4f;
        else if (CompareTag(TimePlusFive))
            timeToAdd = 5f;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag(Player))
            TriggerOnTimePickupEvent();

        Destroy(gameObject);
    }

    private void TriggerOnTimePickupEvent()
    {
        GameEvents.OnTimePickup?.Invoke(timeToAdd);
    }

}
