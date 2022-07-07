using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger_FirstScene : MonoBehaviour
{
    public Animator animator; // animator reference so we will be able to use its attributes.
    public int levelToLoad;

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int currentLevelIndex) // stores a variable of type int, called currentLevelIndex
    {
        levelToLoad = currentLevelIndex; // store the new value of '1' into 'levelToLoad'
        animator.SetTrigger("FadeOut"); // run animation
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
