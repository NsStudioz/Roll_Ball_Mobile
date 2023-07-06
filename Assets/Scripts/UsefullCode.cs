using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefullCode
{
    #region ---------------------------------------------------MusicManager.cs Old_Functions---------------------------------------------------:

    /*    private IEnumerator FadeInTrack(string name)
        {
            playNextTrack = true;

            Sound s = Array.Find(sounds, sound => sound.name == name);

            if (s == null)
                Debug.Log("Sound:" + name + "not found!");

            timeElapsed = 0f;

            if (playNextTrack)
            {
                s.source.Play();

                while (timeElapsed < timeToFade)
                {
                    s.source.volume = Mathf.Lerp(0, 1, timeElapsed / timeToFade);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }
            }
        }

        private IEnumerator FadeOutTrack(string name)
        {
            stopOldTrack = true;

            Sound s = Array.Find(sounds, sound => sound.name == name);
            if (s == null)
            {
                Debug.Log("Sound:" + name + "not found!");
            }

            timeElapsed = 0f;

            if (stopOldTrack)
            {
                while (timeElapsed < timeToFade)
                {
                    s.source.volume = Mathf.Lerp(1, 0, timeElapsed / timeToFade);
                    timeElapsed += Time.deltaTime;
                    yield return null;
                }
                s.source.Stop();
            }
        }

        private IEnumerator DelayTimeToSwitchBools()
        {
            StartDelayTime = true;

            yield return new WaitForSecondsRealtime(TimerThreshold);

            StartDelayTime = false;
            playNextTrack = false;
            stopOldTrack = false;
        }

        public void SwapTracks(string oldTrack, string newTrack)
        {
            StartCoroutine(FadeOutTrack(oldTrack)); // stop old track, do a fadeout.
            StartCoroutine(FadeInTrack(newTrack)); // start new track, do a fadein.

            StartCoroutine(DelayTimeToSwitchBools()); // start new track, do a fadein.
        }

        public IEnumerator SplashDelayTimeToPlayMainTheme()
        {
            StartCoroutine(FadeInTrack("Theme_Main_Menu"));
            yield return new WaitForSecondsRealtime(TimerThreshold);
            playNextTrack = false;
            stopOldTrack = false;
        }*/

    // Unused
    /*    private bool playNextTrack;
        private bool stopOldTrack;

        private bool StartDelayTime;
        private bool stateSwitch = false;
        private float TimerThreshold = 1f;*/

    #endregion


    #region ---------------------------------------------------Useful_Code---------------------------------------------------

    //private int[] musicTriggerValues = { 12, 17, 22, 27, 31, 34, 39, 42, 49, 51 };

    /*        GameObject forMusicManager = GameObject.Find("MusicManager");
            musicManager = forMusicManager.GetComponent<MusicManager>();*/

    /*        if (musicTriggerValues.Contains(GameSession.Instance.CurrentSceneIndex))
            musicManager.stateSwitch = false;*/

    //decimalTimer = Time.unscaledDeltaTime;

    /*[Header("Scene Elements")]*/
    //[SerializeField] int nextSceneLoad;
    //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;

    /*if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Level Exit")))
    {
    }*/

    // GameObjects:
    //TimerScript timerScript;
    /*        GameObject thisGameSession = GameObject.Find("Gamesession");
        timerScript = thisGameSession.GetComponent<TimerScript>();*/


    /*        if ((animator.GetCurrentAnimatorStateInfo(0).IsName(fadeOutAnim)))
            {
            }*/

    //StartCoroutine(PlayFadeAnimations(animator.GetCurrentAnimatorStateInfo(0).length));

    /*public static bool PauseGame = false;     // public = accessible from other scripts.
                                                // static = we don't want to reference this specific script, 
                                                // we just want to be able to easily check from other scripts whether or not the game is currently paused.*/

    /*        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Traps")))
            {


            }*/

    #endregion


    #region UnlockDoor:

    //StartCoroutine(CountDownTimerToDestroyEffectInstance(particleSystemInstance));

    /*    private IEnumerator CountDownTimerToDestroyEffectInstance()
        {
            yield return new WaitForSeconds(2);
            Destroy(gameObject);
        }*/


    /*    private void PlayUnlockParticles()
        {
            unlockedblockSystem.transform.position = transform.position;
            unlockedblockSystem.Play();
            Destroy(gameObject);
        }*/

    #endregion


    /*    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == playerPrefab) // if this other collision is the Player
        {
            playerPrefab.transform.parent = transform; // Attach Player position to this platform.
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == playerPrefab) // if this other collision is the Player
        {
            playerPrefab.transform.parent = null; // Detach Player position from this platform.
        }
    }*/




}
