using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableBlock : MonoBehaviour
{

    [SerializeField] float scrollRate = 1f;
    [SerializeField] float delayTime = 1f;
    [SerializeField] float timeElapsed = 0f;

    [SerializeField] bool moveRight = true;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (moveRight)
        {
            SideScrollingRight();
            if(timeElapsed > delayTime)
            {
                moveRight = false;
                timeElapsed = 0f;
            }
        }

        if(moveRight == false)
        {
            SideScrollingLeft();
            if (timeElapsed > delayTime)
            {
                moveRight = true;
                timeElapsed = 0f;
            }
        }
    }

    private void SideScrollingRight()
    {

        float xMoveR = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(xMoveR, 0f));
    }
    private void SideScrollingLeft()
    {
        float xMoveL = -scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(xMoveL, 0f));
    }
}
