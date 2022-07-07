using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole_Hscroll : MonoBehaviour
{
    [SerializeField] float scrollRate = 1f;
    [SerializeField] float delayTime = 2f;
    [SerializeField] float timeElapsed = 0f;

    [SerializeField] bool isMovingRight;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        
        if (isMovingRight == true)
        {
            MoveRight();
            if (timeElapsed >= delayTime)
            {
                isMovingRight = false;
                timeElapsed = 0f;
            }
        }

        if (isMovingRight == false)
        {
            MoveLeft();
            if (timeElapsed >= delayTime)
            {
                isMovingRight = true;
                timeElapsed = 0f;
            }
        }
    }

    private void MoveRight()
    {
        float xMoveRight = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(xMoveRight, 0f));
    }

    private void MoveLeft()
    {
        float xMoveLeft = -scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(xMoveLeft, 0f));
    }
}
