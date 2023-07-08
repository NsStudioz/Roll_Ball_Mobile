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
    private void OnInvoked_DetachPlayerFromPlatform() => SetDetachFromPlatform(true);

    private void OnPause_PlayerPlatformDetach()
    {
        SetDetachFromPlatform(true);
        DetachPlayer();
    }
    private void SetDetachFromPlatform(bool state)
    {
        detachFromPlatform = state;
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

    private void SetPlayerObjectParentToRoot(Collider2D player)
    {
        player.gameObject.transform.parent = null;
    }

    private void SetPlayerObjectParentToPlatformObject(Collider2D player)
    {
        player.gameObject.transform.parent = transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(player) && !detachFromPlatform)     // if this other collision is the Player
            SetPlayerObjectParentToPlatformObject(other);        // Attach Player position to this platform.

        else if (other.CompareTag(player) && detachFromPlatform)
        {
            SetPlayerObjectParentToRoot(other);
            DontDestroyOnLoad(other.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(player) && !detachFromPlatform)
            SetPlayerObjectParentToPlatformObject(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(player))           // if this other collision is the Player
            SetPlayerObjectParentToRoot(other); // Detach Player position from this platform.

        DontDestroyOnLoad(other.gameObject);
    }





}
