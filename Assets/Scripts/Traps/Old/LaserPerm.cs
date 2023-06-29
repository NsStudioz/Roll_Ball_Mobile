using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPerm : MonoBehaviour
{

    [SerializeField] private GameObject laserGO;

    [SerializeField] private bool isLaserOn;

    public GameObject laserObject;

    private void Start()
    {
        SetLaserState();
    }

    private void SetLaserState()
    {
        if (isLaserOn == true)
            laserObject.SetActive(true);
        else
            laserObject.SetActive(false);
    }
}
