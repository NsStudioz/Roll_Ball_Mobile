using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;
    private string player = "Player";
    private bool isOutOfTime = false;

    private void OnEnable()
    {
        GameEvents.OnOutOfTime += TriggerOutOfTime;
    }

    private void OnDisable()
    {
        GameEvents.OnOutOfTime -= TriggerOutOfTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(player) && !isOutOfTime) // if this other collision is the Player
        {
            other.gameObject.transform.parent = transform; // Attach Player position to this platform.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag(player)) // if this other collision is the Player
            other.gameObject.transform.parent = null; // Detach Player position from this platform.

        else if (isOutOfTime)
            other.gameObject.transform.parent = null;

        DontDestroyOnLoad(other.gameObject);
    }

    private void TriggerOutOfTime()
    {
        isOutOfTime = true;
    }
}
