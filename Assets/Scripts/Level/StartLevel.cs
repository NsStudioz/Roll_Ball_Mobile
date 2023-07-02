using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    private string player = "Player";

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == player)
            GameEvents.OnLevelStarted?.Invoke();
    }
}
