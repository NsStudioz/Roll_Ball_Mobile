using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Rotate_P : MonoBehaviour
{
    // Block_Rotator_Medium_(P) or any object named with '_(P)' at the end are rotating Positively.

    [SerializeField] int RotationSpeed = -200;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * RotationSpeed));
    }
}
