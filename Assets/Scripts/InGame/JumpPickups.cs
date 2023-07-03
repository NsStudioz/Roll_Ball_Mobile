using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickups : MonoBehaviour
{

    private readonly int jumpPickupOne = 1;
    private readonly int jumpPickupTwo = 2;
    private readonly int jumpPickupThree = 3;

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("JumpsPlusOne"))
            GameEvents.OnJumpPickup?.Invoke(jumpPickupOne);
        if (player.CompareTag("JumpsPlusTwo"))
            GameEvents.OnJumpPickup?.Invoke(jumpPickupTwo);
        if (player.CompareTag("JumpsPlusThree"))
            GameEvents.OnJumpPickup?.Invoke(jumpPickupThree);

        AudioManager.Instance.Play("JumpsPickup");
        Destroy(gameObject);
    }
}


