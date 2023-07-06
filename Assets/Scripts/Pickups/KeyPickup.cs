﻿using System.Collections;
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
            AudioManager.Instance.Play("KeyPickup");
            GameEvents.OnKeyPickup(keys);
            Destroy(gameObject);
        }
    }
}