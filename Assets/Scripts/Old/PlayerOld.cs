using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*    public void MobileBallJump()
        {
            if (Input.GetButtonDown("Jump") && gameSession.playerRemJumps > 0)
            {
                myRigidBody2D.AddForce(transform.up * ballJumpSpeed);
                gameSession.JumpsMinusOne();
                timerScript.exitOnTime = false;
                timerScript.startTimer = true;

                FindObjectOfType<AudioManager>().Play("PlayerJump");
            }
            else
            {
                return;
            }
        }*/



    /*    public void MobileMoveBallRight()
        {
            if (touch.phase == TouchPhase.Began)
            {
                myRigidBody2D.AddForce(new Vector2(ballMoveSpeed, 0f) * 20f * Time.deltaTime);
                if (myRigidBody2D.velocity.x > 0 || myRigidBody2D.velocity.x < 0)
                {
                    timerScript.exitOnTime = false;
                }
                while (touch.phase == TouchPhase.Stationary)
                {
                    var xMoveR = ballMoveSpeed * Time.deltaTime;
                    myRigidBody2D.AddForce(new Vector2(ballMoveSpeed, 0f) * 20f * Time.deltaTime);
                }
            }
        }*/



    /*    public void MobileMoveBallLeft()
        {
            if (touch.phase == TouchPhase.Began)
            {
                myRigidBody2D.AddForce(new Vector2(-ballMoveSpeed, 0f) * 20f * Time.deltaTime);
                if (myRigidBody2D.velocity.x > 0 || myRigidBody2D.velocity.x < 0)
                {
                    timerScript.exitOnTime = false;
                }
                if (Input.GetButton("Fire1"))
                {
                    var xMoveL = -ballMoveSpeed * Time.deltaTime;
                    myRigidBody2D.AddForce(new Vector2(-ballMoveSpeed, 0f) * 20f * Time.deltaTime);
                }
            }
        }*/



    /*    private void Testings()
        {
            if (touch.phase == TouchPhase.Stationary)
            {
                var xMoveL = -ballMoveSpeed * Time.deltaTime;
                myRigidBody2D.transform.Translate(new Vector2(xMoveL, 0f));
            }
        }*/

    /*public void Jump()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        myRigidBody2D.AddForce(transform.up * ballJumpSpeed);
    }
}*/


    /*    public void NewBallJump()
    {
        if(SimpleInput.GetButtonDown("Jump") && gameSession.playerRemJumps > 0)
        {
            Vector2 jumpVelocity = new Vector2(myRigidBody2D.velocity.x, ballJumpSpeed);
            myRigidBody2D.velocity = jumpVelocity;
            gameSession.JumpsMinusOne();
            timerScript.exitOnTime = false;
            timerScript.startTimer = true;

            FindObjectOfType<AudioManager>().Play("PlayerJump");
        }
        else
        {
            return;
        }
    }*/


    // Movement:

    /*    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        float xMove = SimpleInput.GetAxis("Horizontal");
    }*/

    //
    // myRigidBody2D.velocity = new Vector2(xMove * ballMoveSpeed * Time.deltaTime, 0f);
    // myRigidBody2D.velocity = new Vector2(xMove, 0f) * ballMoveSpeed * Time.deltaTime;
    //

    /*    private void MoveBall()
    {
        myRigidBody2D.AddForce(new Vector2(xInput, 0f) * ballMoveSpeed * Time.deltaTime);
        if (myRigidBody2D.velocity.x > 0 || myRigidBody2D.velocity.x < 0)
        {
            timerScript.exitOnTime = false;
        }
    }*/


}
