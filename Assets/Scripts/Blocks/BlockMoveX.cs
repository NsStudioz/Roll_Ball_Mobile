using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMoveX : MonoBehaviour
{

    [Header("Elements")]
    [SerializeField] private bool isMovingRight;
    //
    [SerializeField] private float moveRate;
    [SerializeField] private float range;
    [SerializeField] private float rangeLimit;


    void Update()
    {
        SetMovementState(isMovingRight);
        CalculateDurationOfState();
    }

    private void CalculateDurationOfState()
    {
        if (range >= rangeLimit)
        {
            isMovingRight = !isMovingRight;
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
        float xDirection = moveRate * deltaTime;
        transform.Translate(new Vector2(xDirection, 0f));
        range += Mathf.Abs(xDirection);
    }
}
