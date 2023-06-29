using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttaches : MonoBehaviour
{
    public GameObject Player;
    public GameObject Pickups;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject == Player || other.gameObject == Pickups)
        {

        }

    }
}
