using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour
{

    int keys = 1;

    private void OnTriggerEnter2D(Collider2D player)
    {
        AudioManager.Instance.Play("KeyPickup");
        GameEvents.OnKeyPickup(keys);
        Destroy(gameObject);
    }
}
