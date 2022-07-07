using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Serialized/Public Variables
    [SerializeField] float ballMoveSpeed = 4f;
    [SerializeField] float ballJumpSpeed = 5f;
    [SerializeField] float delayBeforeLoading = 1.5f; // in seconds
    [SerializeField] float timeElapsed;
    //
    public int nextSceneLoad;
    public int currentSceneIndex;
    public bool isDestroyed = false;
    public int sceneIndex = 1;
    // References:
    Rigidbody2D myRigidBody2D;
    CapsuleCollider2D myBodyCollider;
    SpriteRenderer mySpriteRenderer;
    // GameObjects:
    GameSession gameSession;
    TimerScript timerScript;
    // Particles:
    public ParticleSystem system;

    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        //
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //
        GameObject thisGameSession = GameObject.Find("Gamesession");
        gameSession = thisGameSession.GetComponent<GameSession>();
        timerScript = thisGameSession.GetComponent<TimerScript>();
        //
        gameSession.playerRemJumps = 3;
        gameSession.keyCount = 0;
        timerScript.decimalLevelTimer = 10f;
        timerScript.timerText.text = timerScript.levelTimer.ToString();
        timerScript.isTimeOutPlayed = false;
        timerScript.startTimer = false;
        timerScript.exitOnTime = false;
    }

    void Update() // Suitable for Handling inputs and animations
    {
        TriggeringLevelExit();
        PlayerDeath();
        ReturnToCurrentScene();
        OutOfTime();

        //PC CONTROLS:
        PcJumpMechanic();
    }

    void FixedUpdate() // Suitable for Movement;
    {
        MoveBall();
    }
    
    public void MoveBall()
    {
        float xMove = SimpleInput.GetAxis("Horizontal");
        myRigidBody2D.AddForce(new Vector2(xMove * ballMoveSpeed * Time.deltaTime, 0f));
    }

    public void Jump()
    {
        if (gameSession.playerRemJumps == 0 || isDestroyed)
        {
            return;
        }
        else
        {
            Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
            myRigidBody2D.velocity = jumpVelocity;
            gameSession.JumpsMinusOne();
            timerScript.exitOnTime = false;
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
    }

    public void HoldButton() // Jump when press
    {
        if (gameSession.playerRemJumps == 0 || isDestroyed)
        {
            return;
        }
        else
        {
            Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
            myRigidBody2D.velocity = jumpVelocity;
            gameSession.JumpsMinusOne();
            timerScript.exitOnTime = false;
            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
    }

    public void ReleaseButton() // Do nothing upon release
    {
        return;
    }


    public void TriggeringLevelExit()
    {
        if(myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Level Exit")))
        {
            if (SceneManager.GetActiveScene().buildIndex == 52)
            {
                FindObjectOfType<LevelChanger_Levels>().FadeToMainMenu();
                timerScript.exitOnTime = true;
                myRigidBody2D.simulated = false;
                FindObjectOfType<AudioManager>().Play("LevelCompleted");
            }
            else
            {
                FindObjectOfType<LevelChanger_Levels>().FadeToNextLevel();
                // Setting Int for Index
                if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))  { PlayerPrefs.SetInt("levelAt", nextSceneLoad); }
                timerScript.exitOnTime = true;
                myRigidBody2D.simulated = false;
                //
                FindObjectOfType<AudioManager>().Play("LevelCompleted");
            }
        }
    }

    private void PlayerDeath()
    {
        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Traps")))
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeath");
            system.Play();
            isDestroyed = true;
            myRigidBody2D.simulated = false; // disable physics of object completely.
            mySpriteRenderer.enabled = false; // disable SpriteRenderer2D.
            timerScript.playerDied = true;
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
                timerScript.playerDied = false;
            }
        }
    }

    public void OutOfTime()
    {
        if (timerScript.timesUp == true)
        {
            timerScript.PlayTimeOutClip();
            myRigidBody2D.simulated = false;
        }
    }

    // [SerializeField] float xInput;
    // [SerializeField] float particleDuration = 0.5f; // Player's Death Particle

    // PC Controls:
    private void PcJumpMechanic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameSession.playerRemJumps == 0 || isDestroyed)
            {
                return;
            }
            else
            {
                Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
                myRigidBody2D.velocity = jumpVelocity;
                gameSession.JumpsMinusOne();
                timerScript.exitOnTime = false;
                FindObjectOfType<AudioManager>().Play("PlayerJump");
            }
        }

    }


}
