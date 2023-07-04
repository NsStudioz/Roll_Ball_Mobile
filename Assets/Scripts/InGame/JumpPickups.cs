using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickups : MonoBehaviour
{

    [SerializeField] private int jumpsToAdd;
    private readonly string Player = "Player";
    //
    private readonly string jumpPickupOne = "JumpsPlusOne";
    private readonly string jumpPickupTwo = "JumpsPlusTwo";
    private readonly string jumpPickupThree = "JumpsPlusThree";

    private void Start()
    {
        InitializeValue();
    }

    private void InitializeValue()
    {
        if (CompareTag(jumpPickupOne))
            jumpsToAdd = 1;
        else if (CompareTag(jumpPickupTwo))
            jumpsToAdd = 2;
        else if (CompareTag(jumpPickupThree))
            jumpsToAdd = 3;
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag(Player))
            GameEvents.OnJumpPickup?.Invoke(jumpsToAdd);

        AudioManager.Instance.Play("JumpsPickup");
        Destroy(gameObject);
    }
}


