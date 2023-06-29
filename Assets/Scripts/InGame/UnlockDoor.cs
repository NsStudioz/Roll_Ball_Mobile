using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{

    [SerializeField] ParticleSystem unlockedblockSystem;

    private int keys = -1;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && GameSession.Instance.GetPlayerKeyCount() > 0)
        {
            GameSession.Instance.CalculateRemainingKeys(keys);
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


/*    GameSession gameSession;

    void Start()
    {
        GameObject thisGameSession = GameObject.Find("Gamesession");
        gameSession = thisGameSession.GetComponent<GameSession>();
    }*/

//gameSession.SubtractFromKeys(1);
//FindObjectOfType<AudioManager>().Play("BlockUnlock");