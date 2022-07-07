using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_Vscroll : MonoBehaviour
{
    [SerializeField] float scrollRate;
    [SerializeField] float posRange;
    [SerializeField] float negRange;
    [SerializeField] float posRangeLimit;
    [SerializeField] float negRangeLimit;

    // bool:
    [SerializeField] bool isScrollingUp;

    void FixedUpdate()
    {
        if(isScrollingUp == true)
        {
            ScrollUp();

            if(posRange >= posRangeLimit)
            {
                isScrollingUp = false;
                posRange = 0f;
            }
        }

        if(isScrollingUp == false)
        {
            ScrollDown();

            if(negRange <= negRangeLimit)
            {
                isScrollingUp = true;
                negRange = 0f;
            }
        }
    }

    private void ScrollUp()
    {
        float yMoveUp = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMoveUp));
        posRange += yMoveUp;
    }

    private void ScrollDown()
    {
        float yMoveDown = -scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMoveDown));
        negRange += yMoveDown;
    }
}
