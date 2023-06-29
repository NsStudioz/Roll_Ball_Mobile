using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole_Vertical : MonoBehaviour
{
    [SerializeField] private float scrollRate = 1f;
    [SerializeField] private float delayTime = 2f;
    [SerializeField] private float timeElapsed = 0f;

    [SerializeField] private bool isMovingUp;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        SetMovementState(isMovingUp);
        CalculateDurationOfState();
    }

    private void SetMovementState(bool state)
    {
        if (state)
            Move(scrollRate, Time.deltaTime); // Move Up
        else
            Move(-scrollRate, Time.deltaTime); // Move Down

    }

    private void Move(float moveRate, float deltaTime)
    {
        float yDirection = moveRate * deltaTime;
        transform.Translate(new Vector2(0f, yDirection));
    }

    private void CalculateDurationOfState()
    {
        if (timeElapsed >= delayTime)
        {
            isMovingUp = !isMovingUp;
            timeElapsed = 0f;
        }
    }



}
