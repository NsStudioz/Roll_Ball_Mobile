using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockVFX : MonoBehaviour
{

    void Awake()
    {
        StartCoroutine(CountDownTimerToDestroyEffectInstance());
    }

    private IEnumerator CountDownTimerToDestroyEffectInstance()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
