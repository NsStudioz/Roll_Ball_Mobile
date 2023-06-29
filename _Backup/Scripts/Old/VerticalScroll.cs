using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalScroll : MonoBehaviour
{

    [SerializeField] float scrollRate = 3f;
    [SerializeField] float delayTime = 2f;
    [SerializeField] float timeElapsed = 0f;

    [SerializeField] bool moveUp = true;



    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (moveUp)
        {
            ScrollUp();
            if (timeElapsed > delayTime)
            {
                moveUp = false;
                timeElapsed = 0f;
            }
        }

        if (moveUp == false)
        {
            ScrollDown();
            if (timeElapsed > delayTime)
            {
                moveUp = true;
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
