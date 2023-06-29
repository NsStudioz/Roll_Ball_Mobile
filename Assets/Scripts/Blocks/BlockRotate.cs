using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotate : MonoBehaviour
{
    [SerializeField] int rotationSpeed;

    void Update()
    {
        RotateBlock();
    }

    private void RotateBlock()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotationSpeed));
    }

}
