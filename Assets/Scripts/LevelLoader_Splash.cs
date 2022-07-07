using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader_Splash : MonoBehaviour
{
    [SerializeField] public float timeElapesd = 0f;
    [SerializeField] public float delayTime = 5f;

    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex < 1)
        {
            timeElapesd += Time.deltaTime;

            if (timeElapesd >= delayTime)
            {
                FindObjectOfType<LevelChanger_FirstScene>().FadeToNextLevel();
            }
            else
            {
                return;
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
