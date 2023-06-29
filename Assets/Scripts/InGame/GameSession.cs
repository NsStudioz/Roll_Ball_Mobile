using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{

    public static GameSession Instance;


    [SerializeField] private int currentSceneIndex;

    public int playerRemJumps; // player's remaining jumps.
    public int keyCount;
    //
    [SerializeField] private TMP_Text jumpsText;
    [SerializeField] private TMP_Text keysText;
    [SerializeField] private GameObject keysImageObject;
    [SerializeField] private GameObject keysTextObject;
    
    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (Instance == null) { Instance = this; } // singleton pattern
        else
        {
            Destroy(gameObject);
            return; // so that no more code is called before we destroy this gameObject.
        }

        DontDestroyOnLoad(gameObject);
    }
    
    public int GetPlayerRemainingJump()
    {
        return playerRemJumps;
    }

    public int GetPlayerKeyCount()
    {
        return keyCount;
    }

    void Update()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        KeysObjectsAppearance();
    }

    public void SetTexts()
    {
        jumpsText.text = playerRemJumps.ToString();
        keysText.text = keyCount.ToString();
    }

    public void CalculateRemainingJumps(int jumps)
    {
        playerRemJumps += jumps;
        jumpsText.text = playerRemJumps.ToString();
    }

    public void CalculateRemainingKeys(int keys)
    {
        keyCount += keys;
        keysText.text = keyCount.ToString();
    }

    public int GetSceneIndex()
    {
        return currentSceneIndex;
    }

    private void SetSceneIndex()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }


    private void KeysObjectsAppearance()
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
}

//InitOld();

/*    private void InitOld()
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
    }*/


//jumpsText.text = playerRemJumps.ToString();
//keysText.text = keyCount.ToString();

/*    public void JumpsMinusOne()
{
    playerRemJumps--;
    jumpsText.text = playerRemJumps.ToString();
}*/

/*    public void AddToJumps(int jumpPickupsToAdd)
    {
        playerRemJumps += jumpPickupsToAdd;
        jumpsText.text = playerRemJumps.ToString();
    }*/


/*    public void AddToKeys(int keysToAdd)
    {
        keyCount = keyCount + keysToAdd;
        keysText.text = keyCount.ToString();
    }*/

/*    public void SubtractFromKeys(int keysToRemove)
    {
        keyCount = keyCount - keysToRemove;
        keysText.text = keyCount.ToString();
    }*/





