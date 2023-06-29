using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickups : MonoBehaviour
{
    float jumpPickups = 0.5f;
    GameSession gameSession;

    void Start()
    {
        GameObject myGameSession = GameObject.Find("Gamesession");
        gameSession = myGameSession.GetComponent<GameSession>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (tag == "JumpsPlusOne")
        {
            gameSession.AddToJumps(jumpPickups);
        }
        if (tag == "JumpsPlusTwo")
        {
            gameSession.AddToJumps(jumpPickups + 0.5f);
        }
        if (tag == "JumpsPlusThree")
        {
            gameSession.AddToJumps(jumpPickups + 1f);
        }

        FindObjectOfType<AudioManager>().Play("JumpsPickup");
        Destroy(gameObject);
    }
}
