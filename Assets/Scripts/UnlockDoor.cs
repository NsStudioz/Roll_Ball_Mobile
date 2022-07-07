using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    // int keysUsed = 1;
    GameSession gameSession;

    public ParticleSystem unlockedblockSystem;

    void Start()
    {
        GameObject thisGameSession = GameObject.Find("Gamesession");
        gameSession = thisGameSession.GetComponent<GameSession>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && gameSession.keyCount > 0)
        {
            gameSession.SubtractFromKeys(1);
            FindObjectOfType<AudioManager>().Play("BlockUnlock");
            PlayUnlockParticles();
        }
    }

    public void PlayUnlockParticles()
    {
        unlockedblockSystem.transform.position = transform.position;
        unlockedblockSystem.Play();
        Destroy(gameObject);
    }


}
