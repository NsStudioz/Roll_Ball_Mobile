using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePickups : MonoBehaviour
{

    private readonly float TimePlusOne =   1f;
    private readonly float TimePlusTwo =   2f;
    private readonly float TimePlusThree = 3f;
    private readonly float TimePlusFour =  4f;
    private readonly float TimePlusFive =  5f;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if(player.CompareTag("TimePlusOne"))
            GameEvents.OnTimePickup?.Invoke(TimePlusOne);
        if (player.CompareTag("TimePlusTwo"))
            GameEvents.OnTimePickup?.Invoke(TimePlusTwo);
        if (player.CompareTag("TimePlusThree"))
            GameEvents.OnTimePickup?.Invoke(TimePlusThree);
        if (player.CompareTag("TimePlusFour"))
            GameEvents.OnTimePickup?.Invoke(TimePlusFour);
        if (player.CompareTag("TimePlusFive"))
            GameEvents.OnTimePickup?.Invoke(TimePlusFive);

        AudioManager.Instance.Play("TimePickup");
        Destroy(gameObject);
    }
}
