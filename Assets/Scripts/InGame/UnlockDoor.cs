using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{

    [SerializeField] ParticleSystem unlockedblockSystem;

    private int keys = -1;
    private string player = "Player";

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == player && GameSession.Instance.KeyCount > 0)
        {
            GameEvents.OnKeyUsed(keys);
            AudioManager.Instance.Play("BlockUnlock");
            PlayUnlockParticles();
        }
    }

    private void PlayUnlockParticles()
    {
        unlockedblockSystem.transform.position = transform.position;
        unlockedblockSystem.Play();
        Destroy(gameObject);
    }
}