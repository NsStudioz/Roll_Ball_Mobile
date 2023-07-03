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

    [Header("Tags")]
    [SerializeField] private string TRAPS_TAG = "Traps";
    [SerializeField] private string EXITLEVEL_TAG = "ExitLevel";


    private void OnEnable()
    {
        GameEvents.OnOutOfTime += OutOfTime;
        PlayerJumpButton.OnButtonClickDown += HoldButton;
        PlayerJumpButton.OnButtonClickUp += ReleaseButton;
    }
    private void OnDisable()
    {
        GameEvents.OnOutOfTime -= OutOfTime;
        PlayerJumpButton.OnButtonClickDown -= HoldButton;
        PlayerJumpButton.OnButtonClickUp -= ReleaseButton;
    }


    private void Update() // Suitable for Handling inputs and animations
    {
        PlayerDeath();
        ReturnToCurrentScene();

#if UNITY_EDITOR
        //PC CONTROLS:
        PcJumpMechanic();
#endif
    }

    private void FixedUpdate() // Suitable for Movement;
    {
        MoveBall();
    }
    
    private void MoveBall()
    {
        float xMove = SimpleInput.GetAxis("Horizontal");
        myRigidBody2D.AddForce(new Vector2(xMove * ballMoveSpeed * Time.deltaTime, 0f));
    }


    #region Player_Jump_Functions:

    // Function for mobile devices.
    private void HoldButton() // Jump when press
    {
        if (GameSession.Instance.PlayerJumps == 0 || isDestroyed)
        {
            return;
        }
        else
        {
            Jump();
            GameEvents.OnPlayerJump?.Invoke(jumpOnce);
            AudioManager.Instance.Play("PlayerJump");
        }
    }

    private void Jump()
    {
        Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
        myRigidBody2D.velocity = jumpVelocity;
    }

    // Function for mobile devices.
    private void ReleaseButton() // Do nothing upon release
    {
        return;
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
                GameEvents.OnPlayerJump?.Invoke(jumpOnce);
                AudioManager.Instance.Play("PlayerJump");
            }
        }
    }

    #endregion

    private void OutOfTime()
    {
        myRigidBody2D.simulated = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EXITLEVEL_TAG))
        {
            SetRigidBodyAndRendererComponentsState(false, true);
        }
        if (other.CompareTag(TRAPS_TAG))
        {
            isDestroyed = true;
            PlayerHasDied();
        }
    }

    private void PlayerHasDied()
    {
        if (isDestroyed)
            SetRigidBodyAndRendererComponentsState(false, false);

        GameEvents.OnPlayerDead?.Invoke();
        AudioManager.Instance.Play("PlayerDeath");
        system.Play();
    }

    private void SetRigidBodyAndRendererComponentsState(bool rigidBody2D, bool renderer)
    {
        myRigidBody2D.simulated = rigidBody2D;
        mySpriteRenderer.enabled = renderer;
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
            GameEvents.OnPlayerDead?.Invoke();
        }
    }

    // USE OBJECT SPAWNER INSTEAD:
    private void ReturnToCurrentScene()
    {
        if (isDestroyed)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed > delayBeforeLoading)
            {
                //FindObjectOfType<LevelChanger_Levels>().FadeToCurrentLevel();
                GameEvents.OnTriggerStopTimer.Invoke();
            }
        }
    }


}

