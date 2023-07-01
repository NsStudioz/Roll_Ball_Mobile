using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    [Header("Objects")]
    [SerializeField] private Rigidbody2D myRigidBody2D;
    [SerializeField] private CapsuleCollider2D myBodyCollider;
    [SerializeField] private SpriteRenderer mySpriteRenderer;
    [SerializeField] private ParticleSystem system;

    [Header("Player Elements")]
    [SerializeField] float ballMoveSpeed = 4f;
    [SerializeField] float ballJumpSpeed = 5f;
    [SerializeField] bool isDestroyed = false;
    private readonly int jumpOnce = -1;

    [Header("Player Spawn Timer")]
    [SerializeField] float delayBeforeLoading = 1.5f; // in seconds
    [SerializeField] float timeElapsed;

    [Header("Scene Elements")]
    [SerializeField] int nextSceneLoad;

    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnEnable()
    {
        PlayerEvents.OnOutOfTime += OutOfTime;
    }
    private void OnDisable()
    {
        PlayerEvents.OnOutOfTime -= OutOfTime;
    }


    void Update() // Suitable for Handling inputs and animations
    {
        TriggeringLevelExit();
        PlayerDeath();
        ReturnToCurrentScene();

#if UNITY_EDITOR
        //PC CONTROLS:
        PcJumpMechanic();
#endif
    }

    void FixedUpdate() // Suitable for Movement;
    {
        MoveBall();
    }
    
    private void MoveBall()
    {
        float xMove = SimpleInput.GetAxis("Horizontal");
        myRigidBody2D.AddForce(new Vector2(xMove * ballMoveSpeed * Time.deltaTime, 0f));
    }

    public void HoldButton() // Jump when press
    {
        if (GameSession.Instance.PlayerJumps == 0 || isDestroyed)
        {
            return;
        }
        else
        {
            Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
            myRigidBody2D.velocity = jumpVelocity;
            //GameSession.Instance.CalculatePlayerJumps(jumpOnce);
            PlayerEvents.OnPlayerJump?.Invoke(jumpOnce);
            AudioManager.Instance.Play("PlayerJump");
        }
    }

    public void ReleaseButton() // Do nothing upon release
    {
        return;
    }

    private void OutOfTime()
    {
        myRigidBody2D.simulated = false;
    }

    private void TriggeringLevelExit()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Level Exit")))
        {
            PlayerEvents.OnLevelCompleted?.Invoke();

            if (SceneManager.GetActiveScene().buildIndex == 52)
            {
                FindObjectOfType<LevelChanger_Levels>().FadeToMainMenu();
                PlayerEvents.OnTriggerStopTimer?.Invoke();
                myRigidBody2D.simulated = false;
                AudioManager.Instance.Play("LevelCompleted");
            }
            else
            {
                FindObjectOfType<LevelChanger_Levels>().FadeToNextLevel();
                // Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))  { PlayerPrefs.SetInt("levelAt", nextSceneLoad); }
                PlayerEvents.OnTriggerStopTimer?.Invoke();
                myRigidBody2D.simulated = false;
                //
                AudioManager.Instance.Play("LevelCompleted");
            }
        }
    }

    private void PlayerDeath()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Traps")))
        {
            AudioManager.Instance.Play("PlayerDeath");
            system.Play();
            isDestroyed = true;
            myRigidBody2D.simulated = false; // disable physics completely.
            mySpriteRenderer.enabled = false; // disable sprite visibility.
            PlayerEvents.OnTriggerStopTimer?.Invoke();
        }
    }

    private void ReturnToCurrentScene()
    {
        if (isDestroyed)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > delayBeforeLoading)
            {
                FindObjectOfType<LevelChanger_Levels>().FadeToCurrentLevel();
                PlayerEvents.OnTriggerStopTimer.Invoke();
            }
        }
    }

    // PC Controls:
    private void PcJumpMechanic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameSession.Instance.PlayerJumps == 0 || isDestroyed)
            {
                return;
            }
            else
            {
                Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
                myRigidBody2D.velocity = jumpVelocity;
                //GameSession.Instance.CalculatePlayerJumps(jumpOnce);
                PlayerEvents.OnPlayerJump?.Invoke(jumpOnce);
                AudioManager.Instance.Play("PlayerJump");
            }
        }
    }
}


//GameSession.Instance.keyCount = 0;

// GameObjects:
//TimerScript timerScript;
/*        GameObject thisGameSession = GameObject.Find("Gamesession");
    timerScript = thisGameSession.GetComponent<TimerScript>();*/

//[SerializeField] int currentSceneIndex;
//currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
//[SerializeField] int sceneIndex = 1;


//
/*        timerScript.decimalLevelTimer = 10f;
        timerScript.isTimeOutPlayed = false;
        timerScript.startTimer = false;
*/


//timerScript.exitOnTime = false;
//timerScript.playerDied = false;
//timerScript.exitOnTime = true;
