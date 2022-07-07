using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole_Vscroll : MonoBehaviour
{
    [SerializeField] float scrollRate;
    [SerializeField] float delayTime;
    [SerializeField] float timeElapsed = 0f;

    [SerializeField] bool isScrollingUp;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (isScrollingUp == true)
        {
            ScrollUp();
            if (timeElapsed >= delayTime)
            {
                isScrollingUp = false;
                timeElapsed = 0f;
            }
        }

        if (isScrollingUp == false)
        {
            ScrollDown();
            if (timeElapsed >= delayTime)
            {
                isScrollingUp = true;
                timeElapsed = 0f;
            }
        }
    }

    private void ScrollUp()
    {
        float yMoveUp = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMoveUp));
    }

    private void ScrollDown()
    {
        float yMoveDown = -scrollRate * Time.deltaTime;
        transform.Translate(new Vector2(0f, yMoveDown));
    }

}
