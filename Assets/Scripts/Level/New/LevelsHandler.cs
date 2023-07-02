using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsHandler : MonoBehaviour
{

    public static LevelsHandler Instance;

    [SerializeField] private Animator animator;
    private int levelIndex;

    [SerializeField] private string fadeInAnim;
    [SerializeField] private string fadeOutAnim;

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

        animator.Play(fadeOutAnim);
        AudioManager.Instance.Play("LevelChoosed");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelIndex);

        // Music Manager swap tracks from main theme to level theme:
    }



}

//animator.SetTrigger("FadeOut");
//FindObjectOfType<AudioManager>().Play("LevelChoosed");
