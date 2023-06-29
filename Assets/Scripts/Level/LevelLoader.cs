using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    int currentSceneIndex;

    public void StartGame()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        FindObjectOfType<AudioManager>().Play("ButtonClick");
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
