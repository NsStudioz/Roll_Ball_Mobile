using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int currentSceneIndex;

    public float playerRemJumps; // player's remaining jumps.
    public int keyCount;
    //
    public TMP_Text jumpsText;
    public TMP_Text keysText;
    public GameObject keysImageObject;
    public GameObject keysTextObject;
    
    private void Awake()
    {
        int numGameSession = FindObjectsOfType<GameSession>().Length;

        if (numGameSession > 1)
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
        jumpsText.text = playerRemJumps.ToString();
        keysText.text = keyCount.ToString();
    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        KeysObjectsAppearance();
        jumpsText.text = playerRemJumps.ToString();
        keysText.text = keyCount.ToString();

    }

    public void JumpsMinusOne()
    {
        playerRemJumps--;
        jumpsText.text = playerRemJumps.ToString();
    }

    public void AddToJumps(float jumpPickupsToAdd)
    {
        playerRemJumps += jumpPickupsToAdd;
        jumpsText.text = playerRemJumps.ToString();
    }
    
    public void AddToKeys(int keysToAdd)
    {
        keyCount = keyCount + keysToAdd;
        keysText.text = keyCount.ToString();
    }

    public void SubtractFromKeys(int keysToRemove)
    {
        keyCount = keyCount - keysToRemove;
        keysText.text = keyCount.ToString();
    }

    public void KeysObjectsAppearance()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(sceneIndex >= 32)
        {
            keysImageObject.SetActive(true);
            keysTextObject.SetActive(true);
        }
        else
        {
            keysImageObject.SetActive(false);
            keysTextObject.SetActive(false);
        }
    }


    /*    public void MusicSwapping()
    {
        MusicManager.instance.StopAllMusic();

        while (currentSceneIndex >= 3 && currentSceneIndex <= 12)
        {
            MusicManager.instance.Play("Theme_1_10");
            return;
        }
        while (currentSceneIndex >= 13 && currentSceneIndex <= 17)
        {
            MusicManager.instance.Play("Theme_11_15");
            return;
        }
    }*/

    /*        int numGameSession = FindObjectsOfType<Gamesession>().Length;

        if (numGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }*/

}





