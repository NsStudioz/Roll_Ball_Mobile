using System;
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
    [SerializeField] private float ballMoveSpeed = 4f;
    [SerializeField] private float ballJumpSpeed = 5f;
    [SerializeField] private bool isDestroyed = false;
    private readonly int jumpOnce = -1;

    [Header("Tags")]
    [SerializeField] private string TRAPS_TAG = "Traps";
    [SerializeField] private string EXITLEVEL_TAG = "ExitLevel";
    [SerializeField] private string STARTLEVEL_TAG = "StartLevel";

    [Header("Tags")]
    [SerializeField] private GameObject startLevelPrefab = null;



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        GameEvents.OnOutOfTime += OutOfTime;
        PlayerJumpButton.OnButtonClickDown += HoldButton;
        PlayerJumpButton.OnButtonClickUp += ReleaseButton;
    }

    private void OnSceneLoaded(Scene sceneIndex, LoadSceneMode mode)
    {
        myRigidBody2D.Sleep();

        if (sceneIndex.buildIndex > 2 && sceneIndex.buildIndex < 53)
        {
            SetBallPositionToLevelStartPosition();
            SetRigidBodyAndRendererComponentsState(true, true);

            if (myRigidBody2D.IsSleeping())
            {
                myRigidBody2D.WakeUp();
            }
        }
        else
        {
            startLevelPrefab = null;
            SetRigidBodyAndRendererComponentsState(false, true);
            //return;
        }
    }

    private void OnDisable()
    {
        GameEvents.OnOutOfTime -= OutOfTime;
        PlayerJumpButton.OnButtonClickDown -= HoldButton;
        PlayerJumpButton.OnButtonClickUp -= ReleaseButton;
        //
        // Method: On Disable => Set rigidbody2D and (MAYBE) Renderer inactive.
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    private void Update() // Suitable for Handling inputs and animations
    {
#if UNITY_EDITOR
        //PC CONTROLS:
        PcJumpMechanic();
#endif
    }

    private void FixedUpdate() // Suitable for Movement;
    {
        MoveBall();
    }

    private void SetBallPositionToLevelStartPosition()
    {
        startLevelPrefab = GameObject.FindGameObjectWithTag(STARTLEVEL_TAG);

        transform.position = startLevelPrefab.transform.position;
        // ON Scene load => set the player position to be equal to the level start position (use LevelStart tag or prefab) + Vector2 offset.
        //                  and enable rigidbody2D.
    }

    private void MoveBall()
    {
        float xMove = SimpleInput.GetAxis("Horizontal");
        myRigidBody2D.AddForce(new Vector2(xMove * ballMoveSpeed * Time.deltaTime, 0f));
    }


    #region Player_Jump_Functions:

    // Mobile Controls:
    private void HoldButton() // Jump when press
    {
        if (GameSession.Instance.PlayerJumps == 0 || isDestroyed) { return; }
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

    // Mobile Controls:
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
        SetRigidBodyAndRendererComponentsState(false, true);
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

    private bool GetIngameScenesIndex()
    {
        return GameSession.Instance.CurrentSceneIndex > 2 && GameSession.Instance.CurrentSceneIndex < 53;
    }


}

