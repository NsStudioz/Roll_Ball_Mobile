using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickups : MonoBehaviour
{

    int jumpPickupOne = 1;
    int jumpPickupTwo = 2;
    int jumpPickupThree = 3;


    private void OnTriggerEnter2D(Collider2D player)
    {
        if (tag == "JumpsPlusOne")
            GameEvents.OnJumpPickup?.Invoke(jumpPickupOne);
        if (tag == "JumpsPlusTwo")
            GameEvents.OnJumpPickup?.Invoke(jumpPickupTwo);
        if (tag == "JumpsPlusThree")
            GameEvents.OnJumpPickup?.Invoke(jumpPickupThree);

        AudioManager.Instance.Play("JumpsPickup");
        Destroy(gameObject);
    }
}

//GameSession.Instance.CalculatePlayerJumps(jumpPickupOne);

//float jumpPickups = 0.5f;

/*    GameSession gameSession;

    void Start()
    {
        GameObject myGameSession = GameObject.Find("Gamesession");
        gameSession = myGameSession.GetComponent<GameSession>();
    }*/


/*        if (tag == "JumpsPlusOne")
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
        }*/


//FindObjectOfType<AudioManager>().Play("JumpsPickup");
