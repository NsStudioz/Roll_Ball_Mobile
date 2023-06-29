using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEffect_M : MonoBehaviour
{

    float sizeChangeDelay = 0.5f;

/*    void Awake()
    {
        transform.localScale = new Vector2(0.9f, 0.9f);
    }

    void Update()
    {
        StartCoroutine(laserSizeChange());
    }*/

    IEnumerator laserSizeChange()
    {
        transform.localScale = new Vector2(1, 0.9f);
        yield return new WaitForSeconds(sizeChangeDelay);
        transform.localScale = new Vector2(0.9f, 0.9f);
    }
}
