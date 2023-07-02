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

    public void FadeToLevel(int currentLevelIndex)
    {
        levelIndex = currentLevelIndex;

        //animator.Play(fadeOutAnim);
        StartFadeAnimations();
        AudioManager.Instance.Play("LevelChoosed");
    }

    private void StartFadeAnimations()
    {
        StartCoroutine(PlayFadeAnimations(FADE_OUT_DURATION));
    }

    private IEnumerator PlayFadeAnimations(float delayTime)
    {
        animator.Play(fadeOutAnim);
        yield return new WaitForSeconds(delayTime);
        OnFadeComplete_SwitchToScene();
    }

    private void OnFadeComplete_SwitchToScene()
    {
        SceneManager.LoadScene(levelIndex);

        // Music Manager swap tracks from main theme to level theme:
    }


/*    public void OnFadeComplete()
    {
        //SceneManager.LoadScene(levelIndex);
    }*/



}

//animator.SetTrigger("FadeOut");
//FindObjectOfType<AudioManager>().Play("LevelChoosed");


/*        if ((animator.GetCurrentAnimatorStateInfo(0).IsName(fadeOutAnim)))
        {
        }*/

//StartCoroutine(PlayFadeAnimations(animator.GetCurrentAnimatorStateInfo(0).length));
//StartCoroutine(PlayFadeAnimations(animator.GetCurrentAnimatorStateInfo(0).IsName(fadeOutAnim)));
