using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsHandler : MonoBehaviour
{

    public static LevelsHandler Instance;

    [SerializeField] private Animator animator;
    [SerializeField] private string fadeInAnim;
    [SerializeField] private string fadeOutAnim;

    private int levelIndex;
    private readonly float FADE_OUT_DURATION = 1f;

    private readonly int MAIN_MENU_INDEX = 1;
    private readonly int ADD_INDEX_BY_ONE = 1;

    private void Awake()
    {
        InitializeSingleton();
    }

    private void InitializeSingleton()
    {
        if (Instance == null) { Instance = this; } // singleton pattern
        else
        {
            Destroy(gameObject);
            return; // so that no more code is called before we destroy this gameObject.
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        GameEvents.OnLevelSelected += FadeToLevel;
        GameEvents.OnLevelCompleted += FadeToNextLevel;
        GameEvents.OnReturnToMainMenu += FadeToMainMenu;
        GameEvents.OnRestartLevel += RestartLevel;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelSelected -= FadeToLevel;
        GameEvents.OnLevelCompleted -= FadeToNextLevel;
        GameEvents.OnReturnToMainMenu -= FadeToMainMenu;
        GameEvents.OnRestartLevel -= RestartLevel;
    }

    private void FadeToMainMenu()
    {
        AudioManager.Instance.Play("ButtonClick");
        FadeToLevel(MAIN_MENU_INDEX);
    }

    private void RestartLevel(int currentLevelIndex)
    {
        AudioManager.Instance.Play("ButtonClick");
        levelIndex = currentLevelIndex;
        OnComplete_SwitchToScene();
    }

    private void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + ADD_INDEX_BY_ONE);
    }

    public void FadeToLevel(int currentLevelIndex)
    {
        levelIndex = currentLevelIndex;
        StartFadeAnimations();
    }

    private void StartFadeAnimations()
    {
        StartCoroutine(PlayFadeAnimations(FADE_OUT_DURATION));
    }

    private IEnumerator PlayFadeAnimations(float delayTime)
    {
        animator.Play(fadeOutAnim);
        yield return new WaitForSeconds(delayTime);
        OnComplete_SwitchToScene();
    }

    private void OnComplete_SwitchToScene()
    {
        SceneManager.LoadScene(levelIndex);

        // Music Manager swap tracks from main theme to level theme:
    }
}

/*    public void OnFadeComplete()
    {
        //SceneManager.LoadScene(levelIndex);
    }*/


//animator.SetTrigger("FadeOut");
//FindObjectOfType<AudioManager>().Play("LevelChoosed");


/*        if ((animator.GetCurrentAnimatorStateInfo(0).IsName(fadeOutAnim)))
        {
        }*/

//StartCoroutine(PlayFadeAnimations(animator.GetCurrentAnimatorStateInfo(0).length));
//StartCoroutine(PlayFadeAnimations(animator.GetCurrentAnimatorStateInfo(0).IsName(fadeOutAnim)));
