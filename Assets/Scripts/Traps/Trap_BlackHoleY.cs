using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_BlackHoleY : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private bool isMovingUp;
    //
    [SerializeField] private float moveRate;
    [SerializeField] private float range;
    [SerializeField] private float rangeLimit;


    void Update()
    {
        SetMovementState(isMovingUp);
        CalculateDurationOfState();
    }

    private void CalculateDurationOfState()
    {
        if (range >= rangeLimit)
        {
            isMovingUp = !isMovingUp;
            range = 0;
        }
    }

    private void SetMovementState(bool state)
    {
        if (state)
            Move(moveRate, Time.deltaTime);
        else
            Move(-moveRate, Time.deltaTime);
    }

    private void Move(float moveRate, float deltaTime)
    {
        float yDirection = moveRate * deltaTime;
        transform.Translate(new Vector2(0f, yDirection));
        range += Mathf.Abs(yDirection);
    }
}
