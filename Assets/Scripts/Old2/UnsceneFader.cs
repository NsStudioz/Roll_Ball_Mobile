using UnityEngine;
using UnityEngine.SceneManagement;

public class UnsceneFader : MonoBehaviour
{
    public Animator animator; // animator reference so we will be able to use its attributes.
    private int levelToLoad;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // if clicked left mouse button
        {
            FadeToLevelSelect(); // when we call this method and pass in the value of '1' (the index)
        }
    }

    public void FadeToLevelSelect()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToCurrentLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex);
    }

    public void FadeToLevel(int currentLevelIndex) // stores a variable of type int, called currentLevelIndex
    {
        levelToLoad = currentLevelIndex; // store the new value of '1' into 'levelToLoad'
        // animator.SetTrigger("FadeOut"); // run animation
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad); // load the scene with the value index of '1' (levelToLoad)
    }

}
