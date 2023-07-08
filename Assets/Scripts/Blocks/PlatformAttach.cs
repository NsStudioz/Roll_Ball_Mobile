using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{

    private readonly string player = "Player";
    private bool detachFromPlatform = false;

    private void OnEnable()
    {
        GameEvents.OnOutOfTime += OnInvoked_DetachPlayerFromPlatform;
        GameEvents.OnPlayerDead += OnInvoked_DetachPlayerFromPlatform;
        UIEvents.OnPause += OnPause_PlayerPlatformDetach;
        UIEvents.OnResume += OnResume_PlayerPlatformAttach;
    }



    private void OnDisable()
    {
        GameEvents.OnOutOfTime -= OnInvoked_DetachPlayerFromPlatform;
        GameEvents.OnPlayerDead -= OnInvoked_DetachPlayerFromPlatform;
        UIEvents.OnPause -= OnPause_PlayerPlatformDetach;
        UIEvents.OnResume -= OnResume_PlayerPlatformAttach;
    }
    private void OnResume_PlayerPlatformAttach() => SetDetachFromPlatform(false);

    private void OnPause_PlayerPlatformDetach()
    {
        SetDetachFromPlatform(true);
        DetachPlayer();
    }

    private void DetachPlayer()
    {
        GameObject playerSingleton = GameObject.FindGameObjectWithTag(player);

        if (playerSingleton != null && detachFromPlatform)
        {
            playerSingleton.gameObject.transform.parent = null;
            DontDestroyOnLoad(playerSingleton);
        }
    }

    private void OnInvoked_DetachPlayerFromPlatform() => SetDetachFromPlatform(true);

    private void SetDetachFromPlatform(bool state)
    {
        detachFromPlatform = state;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(player) && !detachFromPlatform) // if this other collision is the Player
            other.gameObject.transform.parent = transform; // Attach Player position to this platform.
        else if(other.CompareTag(player) && detachFromPlatform)
        {
            other.gameObject.transform.parent = null;
            DontDestroyOnLoad(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(player) && !detachFromPlatform)
        {
            other.gameObject.transform.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(player)) // if this other collision is the Player
            other.gameObject.transform.parent = null; // Detach Player position from this platform.

        else if (other.CompareTag(player) && detachFromPlatform)
            other.gameObject.transform.parent = null;

        DontDestroyOnLoad(other.gameObject);
    }

    private void SetPlayerObjectParentToRoot(Collider2D player)
    {
        player.gameObject.transform.parent = null;
    }

    private void SetPlayerObjectParentToPlatformObject(Collider2D player)
    {
        player.gameObject.transform.parent = transform;
    }



}
