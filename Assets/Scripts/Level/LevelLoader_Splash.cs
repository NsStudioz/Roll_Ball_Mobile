using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_Splash : MonoBehaviour
{
    public Animator animator; 
    [SerializeField] int levelToLoad;

    public void FadeToNextLevel()
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
