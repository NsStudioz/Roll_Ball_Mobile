using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_H_Scroll : MonoBehaviour
{
    [SerializeField] float scrollRate;
    [SerializeField] float posRange;
    [SerializeField] float negRange;
    [SerializeField] float posRangeLimit;
    [SerializeField] float negRangeLimit;

    // bool:
    [SerializeField] bool isMovingRight;

    void FixedUpdate()
    {
        if(isMovingRight == true)
        {
            MoveRight();

            if(posRange >= posRangeLimit)
            {
                isMovingRight = false;
                posRange = 0f;
            }
        }

        if(isMovingRight == false)
        {
            MoveLeft();

            if(negRange <= negRangeLimit)
            {
                isMovingRight = true;
                negRange = 0f;
            }
        }
    }

    private void MoveRight()
    {
        float xMoveRight = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(xMoveRight, 0f));
        posRange += xMoveRight;
    }
    private void MoveLeft()
    {
        float xMoveLeft = -scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(xMoveLeft, 0f));
        negRange += xMoveLeft;
    }
}
