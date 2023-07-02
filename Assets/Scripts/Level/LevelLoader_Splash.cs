using UnityEngine;
using UnityEngine.SceneManagement;


namespace InitSplash
{
    public class LevelLoader_Splash : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private float timeElapesd = 0f;
        [SerializeField] private float delayTime = 5f;

        void Update()
        {
            if (timeElapesd < delayTime)
                timeElapesd += Time.deltaTime;
            else
                FadeToMainMenuScene();
        }

        private void FadeToMainMenuScene()
        {
            animator.SetTrigger("FadeOut");
        }

        // Public since this function depends on the animator:
        public void OnFadeComplete()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}


//private int levelToLoad;
//FadeToLevel();

/*private void FadeToLevel()
{
    animator.SetTrigger("FadeOut");
}*/

//FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
//levelToLoad = currentLevelIndex;
//int currentLevelIndex