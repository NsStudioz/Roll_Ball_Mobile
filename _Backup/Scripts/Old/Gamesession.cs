using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamesession : MonoBehaviour
{

    [SerializeField] int playerLives = 1;
    // [SerializeField] int score = 0;

    [SerializeField] float levelReloadDelay = 2.0f;

    // Text Variables:
    // [SerializeField] Text livesTest;
    // [SerializeField] Text scoreText;
    SceneFader sceneFader;


    private void Awake()
    {
        int numGameSession = FindObjectsOfType<Gamesession>().Length;
        
        if(numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        int numGameSession = FindObjectsOfType<Gamesession>().Length;

        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ProcessPlayerDeath()
    {
        if(playerLives > 1)
        {
            SubtractLife();
        }
        else
        {
            // StartCoroutine(ProcessingPlayerDeath());
            ResetGameSession();
        }
    }

    private void SubtractLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGameSession()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

   // StartCoroutine(ProcessPlayerDeath());

    IEnumerator ProcessingPlayerDeath()
    { 
        yield return new WaitForSeconds(levelReloadDelay);
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }



}
