using UnityEngine;
using UnityEngine.SceneManagement;


namespace InitSplash
{
    public class SplashLoader : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [SerializeField] private float timeElapesd = 0f;
        [SerializeField] private float delayTime = 5f;

        private void Start()
        {
            Application.targetFrameRate = 60;
        }

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
