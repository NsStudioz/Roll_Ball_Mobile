using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPerm : MonoBehaviour
{
    [SerializeField] bool isLaserOn;

    public GameObject laserObject;

    void Update()
    {
        if (isLaserOn == true)
        {
            laserObject.SetActive(true);
        }
        else
        {
            laserObject.SetActive(false);
        }
    }
}
