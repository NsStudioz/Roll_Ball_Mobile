﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == Player) // if this other collision is the Player
        {
            Player.transform.parent = transform; // Attach Player position to this platform.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == Player) // if this other collision is the Player
        {
            Player.transform.parent = null; // Detach Player position from this platform.
        }
    }


}
