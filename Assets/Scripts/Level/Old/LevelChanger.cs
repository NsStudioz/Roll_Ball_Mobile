using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{

    public Animator animator;
    private int levelToLoad;

    public void FadeToLevel (int currentLevelIndex)
    {
        levelToLoad = currentLevelIndex; 

        animator.SetTrigger("FadeOut"); 

        FindObjectOfType<AudioManager>().Play("LevelChoosed");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

}
