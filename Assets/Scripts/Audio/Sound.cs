using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;

    public AudioClip clip;
    

    [Range(0f, 1f)]   // slider range
    public float volume;
    [Range(0.1f, 3f)] // slider range
    public float pitch;

    public bool loop;
    public bool mute;

    [HideInInspector]
    public AudioSource source;

}
