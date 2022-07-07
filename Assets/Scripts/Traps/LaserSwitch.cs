using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitch : MonoBehaviour
{
    [SerializeField] bool isLaserOn = true;
    [SerializeField] float timeElapsed;
    [SerializeField] float delayTime = 2f;

    public GameObject laserObject;

    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (isLaserOn == true)
        {
            laserObject.SetActive(true);
            if (timeElapsed > delayTime)
            {
                isLaserOn = false;
                laserObject.SetActive(false);
                timeElapsed = 0f;
            }
        }

        if (isLaserOn == false)
        {
            laserObject.SetActive(false);
            if (timeElapsed > delayTime)
            {
                isLaserOn = true;
                laserObject.SetActive(true);
                timeElapsed = 0f;
            }
        }
    }
}
