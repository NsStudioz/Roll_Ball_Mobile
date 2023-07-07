using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsEvents
{
    #region Audio_Events:
    public delegate void SoundMuteState();
    public static SoundMuteState OnSoundMuteState;

    public delegate void SoundMute();
    public static SoundMute OnSoundMute;

    #endregion

    #region Music_Events:


    #endregion


}
