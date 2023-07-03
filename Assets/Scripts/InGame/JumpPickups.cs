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


