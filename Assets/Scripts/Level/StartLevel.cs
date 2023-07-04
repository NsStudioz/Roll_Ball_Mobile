using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    private string player = "Player";

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(player))
            GameEvents.OnLevelStarted?.Invoke();
    }
}
