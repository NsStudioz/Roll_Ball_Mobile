using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    int currentSceneIndex;

    public float timeElapesd = 0f;
    public float delayTime = 8f;

    /*void Update()
    {
        if (currentSceneIndex == 0)
        {
            timeElapesd += Time.deltaTime;

            if (timeElapesd >= delayTime)
            {
                FindObjectOfType<LevelChanger_FirstScene>().FadeToNextLevel();
            }
        }
    }*/

    public void StartGame()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        FindObjectOfType<AudioManager>().Play("BackButtonClick");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void CreditsMenu()
    {
        SceneManager.LoadScene("Credits Scene");
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void TutorialScene()
    {
        SceneManager.LoadScene("Tutorial Scene");
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
}
