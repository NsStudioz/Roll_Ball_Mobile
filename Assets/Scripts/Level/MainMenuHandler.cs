using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuHandler : MonoBehaviour
{

    [Header("Menu Scene Indexers")]
    [SerializeField] private int MAIN_MENU_INDEX = 1;
    [SerializeField] private int LEVEL_SELECT_INDEX = 2;
    [SerializeField] private int OPTIONS_INDEX = 53;
    [SerializeField] private int CREDITS_INDEX = 54;
    [SerializeField] private int TUTORIAL_INDEX = 55;

    public void StartGame()
    {
        LoadScene(LEVEL_SELECT_INDEX);
        PlayAudioClipOnButtonClick();
    }

    public void ReturnToMainMenu()
    {
        LoadScene(MAIN_MENU_INDEX);
        PlayAudioClipOnBackButtonClick();
    }

    public void OptionsMenu()
    {
        LoadScene(OPTIONS_INDEX);
        PlayAudioClipOnButtonClick();
    }

    public void CreditsMenu()
    {
        LoadScene(CREDITS_INDEX);
        PlayAudioClipOnButtonClick();

    }

    public void TutorialScene()
    {
        LoadScene(TUTORIAL_INDEX);
        PlayAudioClipOnButtonClick();
    }

    private void LoadScene(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
    }

    private void PlayAudioClipOnButtonClick()
    {
        AudioManager.Instance.Play("ButtonClick");
    }

    private void PlayAudioClipOnBackButtonClick()
    {
        AudioManager.Instance.Play("BackButtonClick");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
