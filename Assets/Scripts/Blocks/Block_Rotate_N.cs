using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Rotate_N : MonoBehaviour
{
    // Block_Rotator_Medium_(N) or any object named with '_(N)' at the end are rotating Negatively.

    [SerializeField] int rotationSpeed = 200;

    void Start() { }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed));
    }
}
