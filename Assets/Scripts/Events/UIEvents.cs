using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEvents
{

    #region PauseMenu_Events:

    public delegate void Pause();
    public static Pause OnPause;

    public delegate void Resume();
    public static Resume OnResume;

    #endregion

    #region MainMenu_Events:

    public delegate void ButtonClicked();
    public static ButtonClicked OnButtonClicked;

    public delegate void BackButtonClicked();
    public static BackButtonClicked OnBackButtonClicked;

    #endregion

    #region AudioSettings_Events:
    public delegate void SoundMuteState();
    public static SoundMuteState OnSoundMuteState;

    public delegate void SoundMute();
    public static SoundMute OnSoundMute;

    #endregion

    #region MusicSettings_Events:

    public delegate void MusicMuteState();
    public static MusicMuteState OnMusicMuteState;

    public delegate void MusicMute();
    public static MusicMute OnMusicMute;

    #endregion


}
