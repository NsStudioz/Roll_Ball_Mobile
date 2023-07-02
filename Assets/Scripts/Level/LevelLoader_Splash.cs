using UnityEngine;
using UnityEngine.SceneManagement;


namespace InitSplash
{
    public class LevelLoader_Splash : MonoBehaviour
    {
        public Animator animator;
        [SerializeField] int levelToLoad;

        [SerializeField] float timeElapesd = 0f;
        [SerializeField] float delayTime = 5f;

        void Update()
        {
            if (timeElapesd < delayTime)
                timeElapesd += Time.deltaTime;
            else
                FadeToMainMenuScene();
        }

        private void FadeToMainMenuScene()
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void FadeToLevel(int currentLevelIndex)
        {
            levelToLoad = currentLevelIndex;
            animator.SetTrigger("FadeOut");
        }

        // Public since this function depends on the animator:
        public void OnFadeComplete()
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
}



//if (SceneManager.GetActiveScene().buildIndex < 1) { }