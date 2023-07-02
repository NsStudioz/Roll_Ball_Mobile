using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    private string player = "Player";

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == player)
            PlayerEvents.OnLevelStarted?.Invoke();
    }
}
