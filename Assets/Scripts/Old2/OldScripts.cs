using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // PauseMenu => Update script:

/*        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }*/
    }


    // Player Script:

    /*    public void BallJump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
                myRigidBody2D.velocity = jumpVelocity;
            }
        }*/


    // LevelChanger_Levels:
    // if (Input.GetMouseButtonDown(1)) {FadeToNextLevel();} // we call this method and pass in the value of '1' (the index), if clicked left mouse button


    // timerscript script:
    // GameObject thisPlayer = GameObject.Find("Player"); //find the Player Game Object, assign it to new variable
    // playerScript = thisPlayer.GetComponent<Player>(); // Assign Player component to thisPlayer


}
