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
    private bool isDestroyed = false;
    private readonly int jumpOnce = -1;

    [Header("Prefabs")]
    [SerializeField] private GameObject startLevelPrefab = null;

    // Tags
    private readonly string TRAPS_TAG = "Traps";
    private readonly string EXITLEVEL_TAG = "ExitLevel";
    private readonly string STARTLEVEL_TAG = "StartLevel";

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;

        GameEvents.OnOutOfTime += OnOutOfTimeInvoked_OutOfTime;
        PlayerJumpButton.OnButtonClickDown += OnButtonClickDownInvoked_HoldButton;
        PlayerJumpButton.OnButtonClickUp += OnButtonClickUpInvoked_ReleaseButton;
    }

    private void OnDisable()
    {
        GameEvents.OnOutOfTime -= OnOutOfTimeInvoked_OutOfTime;
        PlayerJumpButton.OnButtonClickDown -= OnButtonClickDownInvoked_HoldButton;
        PlayerJumpButton.OnButtonClickUp -= OnButtonClickUpInvoked_ReleaseButton;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene sceneIndex, LoadSceneMode mode)
    {
        isDestroyed = false;
        myRigidBody2D.Sleep();

        if (sceneIndex.buildIndex > 2 && sceneIndex.buildIndex < 53)
        {
            SetBallPositionToLevelStartPosition();
            SetRigidBodyAndRendererComponentsState(true, true);

            if (myRigidBody2D.IsSleeping())
                myRigidBody2D.WakeUp();
        }
        else
        {
            startLevelPrefab = null;
            SetRigidBodyAndRendererComponentsState(false, true);
        }
    }

#if UNITY_EDITOR
    private void Update() // Suitable for Handling inputs and animations
    {
        PcJumpMechanic();
    }
#endif

    private void FixedUpdate() // Suitable for Movement;
    {
        MoveBall();
    }

    private void SetBallPositionToLevelStartPosition()
    {
        startLevelPrefab = GameObject.FindGameObjectWithTag(STARTLEVEL_TAG);

        transform.position = startLevelPrefab.transform.position;
    }

    private void MoveBall()
    {
        float xMove = SimpleInput.GetAxis("Horizontal");
        myRigidBody2D.AddForce(new Vector2(xMove * ballMoveSpeed * Time.deltaTime, 0f));
    }


    #region Player_Jump_Functions:

    // Mobile Controls:
    private void OnButtonClickDownInvoked_HoldButton() // Jump when press
    {
        if (GameSession.Instance.PlayerJumps == 0 || isDestroyed) { return; }
        else
        {
            Jump();
            TriggerOnPlayerJumpEvent();
        }
    }

    private void Jump()
    {
        Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
        myRigidBody2D.velocity = jumpVelocity;
    }

    // Mobile Controls:
    private void OnButtonClickUpInvoked_ReleaseButton() // Do nothing upon release
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
                Jump();
                TriggerOnPlayerJumpEvent();
            }
        }
    }

    private void TriggerOnPlayerJumpEvent()
    {
        GameEvents.OnPlayerJump?.Invoke(jumpOnce);
    }

    #endregion

    private void OnOutOfTimeInvoked_OutOfTime()
    {
        SetRigidBodyAndRendererComponentsState(false, true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(EXITLEVEL_TAG))
        {
            SetRigidBodyAndRendererComponentsState(false, true);
        }
        else if (other.CompareTag(TRAPS_TAG))
        {
            isDestroyed = true;
            PlayerHasDied();
        }
    }

    private void PlayerHasDied()
    {
        if (isDestroyed)
            SetRigidBodyAndRendererComponentsState(false, false);

        TriggerOnPlayerDeadEvent();
        system.Play();
    }

    private void SetRigidBodyAndRendererComponentsState(bool rigidBody2D, bool renderer)
    {
        myRigidBody2D.simulated = rigidBody2D;
        mySpriteRenderer.enabled = renderer;
    }


    private void TriggerOnPlayerDeadEvent()
    {
        GameEvents.OnPlayerDead?.Invoke();
    }

}

