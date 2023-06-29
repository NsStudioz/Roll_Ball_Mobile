using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private GameObject playerPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerPrefab) // if this other collision is the Player
        {
            playerPrefab.transform.parent = transform; // Attach Player position to this platform.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject == playerPrefab) // if this other collision is the Player
        {
            playerPrefab.transform.parent = null; // Detach Player position from this platform.
        }
    }


}
