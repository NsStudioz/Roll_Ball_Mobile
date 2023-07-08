using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuHandler : MonoBehaviour
    {

        [Header("Menu Scene Indexers")]
        private readonly int MAIN_MENU_INDEX = 1;
        private readonly int LEVEL_SELECT_INDEX = 2;
        private readonly int OPTIONS_INDEX = 53;
        private readonly int CREDITS_INDEX = 54;
        private readonly int TUTORIAL_INDEX = 55;

        // Button Function:
        public void StartGame()
        {
            LoadScene(LEVEL_SELECT_INDEX);
            TriggerOnButtonClickedEvent();
        }

        // Button Function:
        public void ReturnToMainMenu()
        {
            LoadScene(MAIN_MENU_INDEX);
            TriggerOnBackButtonClickedEvent();
        }

        // Button Function:
        public void OptionsMenu()
        {
            LoadScene(OPTIONS_INDEX);
            TriggerOnButtonClickedEvent();
        }

        // Button Function:
        public void CreditsMenu()
        {
            LoadScene(CREDITS_INDEX);
            TriggerOnButtonClickedEvent();
        }

        // Button Function:
        public void TutorialScene()
        {
            LoadScene(TUTORIAL_INDEX);
            TriggerOnButtonClickedEvent();
        }

        private void LoadScene(int SceneIndex)
        {
            SceneManager.LoadScene(SceneIndex);
        }

        private void TriggerOnBackButtonClickedEvent()
        {
            UIEvents.OnBackButtonClicked?.Invoke();
        }

        private void TriggerOnButtonClickedEvent()
        {
            UIEvents.OnButtonClicked?.Invoke();
        }
    }
}

