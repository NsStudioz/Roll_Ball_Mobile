using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int currentSceneIndex;

    public float playerRemJumps; // player's remaining jumps.
    public int keyCount;
    //
    [SerializeField] TMP_Text jumpsText;
    [SerializeField] TMP_Text keysText;
    [SerializeField] GameObject keysImageObject;
    [SerializeField] GameObject keysTextObject;
    
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





