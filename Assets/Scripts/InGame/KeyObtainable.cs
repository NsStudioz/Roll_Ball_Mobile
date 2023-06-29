using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObtainable : MonoBehaviour
{

    int keys = 1;

    private void OnTriggerEnter2D(Collider2D player)
    {
        AudioManager.Instance.Play("KeyPickup");
        GameSession.Instance.CalculateRemainingKeys(keys);
        Destroy(gameObject);
    }
}

/*
    GameSession gameSession;

    void Start()
    {
        GameObject myGameSession = GameObject.Find("Gamesession");
        gameSession = myGameSession.GetComponent<GameSession>();
    }*/

//FindObjectOfType<AudioManager>().Play("KeyPickup");
//gameSession.AddToKeys(keysObtained);
