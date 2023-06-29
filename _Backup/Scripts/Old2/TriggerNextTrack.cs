using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextTrack : MonoBehaviour
{

    MusicManager musicManager;

    public string oldTrackName;
    public string newTrackName;

    public bool switchToNextTrack = false;

    public float timeElapsed;
    public float timeToFade;

    void Start()
    {
        GameObject forMusicManager = GameObject.Find("MusicManager");
        musicManager = forMusicManager.GetComponent<MusicManager>();
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            musicManager.SwapTracks("Theme_1_10", "Theme_11_15");
        }
    }

}
