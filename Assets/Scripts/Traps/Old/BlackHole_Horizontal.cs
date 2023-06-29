using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole_Horizontal : MonoBehaviour
{
    [SerializeField] private float scrollRate = 1f;
    [SerializeField] private float delayTime = 2f;
    [SerializeField] private float timeElapsed = 0f;

    [SerializeField] private bool isMovingRight;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        SetMovementState(isMovingRight);
        CalculateDurationOfState(isMovingRight);
    }

    private void SetMovementState(bool state)
    {
        if (state)
            Move(scrollRate, Time.deltaTime); // Move Right
        else
            Move(-scrollRate, Time.deltaTime); // Move Left
        
    }

    private void Move(float moveRate, float deltaTime)
    {
        float xDirection = moveRate * deltaTime;
        transform.Translate(new Vector2(xDirection, 0f));
    }

    private void CalculateDurationOfState(bool state)
    {
        if (timeElapsed >= delayTime)
        {
            state = !state;
            timeElapsed = 0f;
        }
    }

}
