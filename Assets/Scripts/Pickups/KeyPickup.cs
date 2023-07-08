using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    int keys = 1;
    private readonly string Player = "Player";


    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag(Player))
        {
            TriggerOnKeyPickupEvent();
            Destroy(gameObject);
        }
    }

    private void TriggerOnKeyPickupEvent()
    {
        GameEvents.OnKeyPickup(keys);
    }

}
