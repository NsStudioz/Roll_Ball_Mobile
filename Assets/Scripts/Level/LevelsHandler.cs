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

    [SerializeField] private float restartLevelTimer = 2f;

    private int levelIndex;
    private readonly float FADE_OUT_DURATION = 1f;

    private readonly int MAIN_MENU_INDEX = 1;
    private readonly int ADD_INDEX_BY_ONE = 1;

    private void Awake() => InitializeSingleton();

    private void InitializeSingleton()
    {
        if (Instance == null)  // singleton pattern
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        GameEvents.OnLevelSelected += OnLevelSelectedInvoked_FadeToLevel;
        GameEvents.OnLevelCompleted += OnLevelCompletedInvoked_FadeToNextLevel;
        GameEvents.OnReturnToMainMenu += OnReturnToMainMenuInvoked_FadeToMainMenu;
        GameEvents.OnRestartLevel += OnRestartLevelInvoked_RestartLevel;
        //
        GameEvents.OnPlayerDead += OnInvoked_CountDownTimerToRestartLevel;
        GameEvents.OnOutOfTime += OnInvoked_CountDownTimerToRestartLevel;
    }

    private void OnDisable()
    {
        GameEvents.OnLevelSelected -= OnLevelSelectedInvoked_FadeToLevel;
        GameEvents.OnLevelCompleted -= OnLevelCompletedInvoked_FadeToNextLevel;
        GameEvents.OnReturnToMainMenu -= OnReturnToMainMenuInvoked_FadeToMainMenu;
        GameEvents.OnRestartLevel -= OnRestartLevelInvoked_RestartLevel;
        //
        GameEvents.OnPlayerDead -= OnInvoked_CountDownTimerToRestartLevel;
        GameEvents.OnOutOfTime -= OnInvoked_CountDownTimerToRestartLevel;
    }

    private void OnReturnToMainMenuInvoked_FadeToMainMenu()
    {
        OnLevelSelectedInvoked_FadeToLevel(MAIN_MENU_INDEX);
    }

    private void OnRestartLevelInvoked_RestartLevel(int currentLevelIndex)
    {
        levelIndex = currentLevelIndex;
        OnComplete_SwitchToScene();
        TriggerOnLevelRestartedEvent();
    }

    private void TriggerOnLevelRestartedEvent()
    {
        GameEvents.OnLevelRestarted?.Invoke();
    }

    private void OnLevelCompletedInvoked_FadeToNextLevel()
    {
        OnLevelSelectedInvoked_FadeToLevel(GameSession.Instance.CurrentSceneIndex + ADD_INDEX_BY_ONE);
    }
    private void OnLevelSelectedInvoked_FadeToLevel(int currentLevelIndex)
    {
        levelIndex = currentLevelIndex;
        StartFadeAnimations();
    }

    private void StartFadeAnimations() => StartCoroutine(PlayFadeAnimations(FADE_OUT_DURATION));

    private IEnumerator PlayFadeAnimations(float delayTime)
    {
        animator.Play(fadeOutAnim);
        yield return new WaitForSeconds(delayTime);
        OnComplete_SwitchToScene();
    }

    private void OnComplete_SwitchToScene()
    {
        SceneManager.LoadScene(levelIndex);
    }

    #region OnPlayerDead + OutOfTime Listeners:

    private void OnInvoked_CountDownTimerToRestartLevel() => StartCoroutine(CountDownTimer());

    private IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(restartLevelTimer);
        OnCountDownTimerEnd_RestartLevel();
    }

    private void OnCountDownTimerEnd_RestartLevel() 
    { 
        OnRestartLevelInvoked_RestartLevel(GameSession.Instance.CurrentSceneIndex); 
    }

    #endregion
}



