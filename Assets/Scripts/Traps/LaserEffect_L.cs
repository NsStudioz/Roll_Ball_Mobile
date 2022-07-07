using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffect_L : MonoBehaviour
{

    float sizeChangeDelay = 0.5f;

    void Awake()
    {
        transform.localScale = new Vector2(1, 1.4f);
    }

    void Update()
    {
        StartCoroutine(laserSizeChange());
    }


    IEnumerator laserSizeChange()
    {
        transform.localScale = new Vector2(1.1f, 1.4f);
        yield return new WaitForSeconds(sizeChangeDelay);
        transform.localScale = new Vector2(1, 1.4f);
    }
}
