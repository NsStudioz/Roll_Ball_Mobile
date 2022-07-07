using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyObtainable : MonoBehaviour
{

    int keysObtained = 1;

    GameSession gameSession;

    void Start()
    {
        GameObject myGameSession = GameObject.Find("Gamesession");
        gameSession = myGameSession.GetComponent<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        FindObjectOfType<AudioManager>().Play("KeyPickup");
        gameSession.AddToKeys(keysObtained);
        Destroy(gameObject);
    }
}
