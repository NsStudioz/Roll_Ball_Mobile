using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img; // public value of type Image, named img.
    public AnimationCurve fadeCurve; 

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(int scene)
    {
        StartCoroutine(FadeOut(scene));
    }







    IEnumerator FadeIn() // a loop that will slowly animate over time at the same grade as our update method would until it reaches a point where we can say load a scene
    {
        float t = 1f;

        while (t > 0f) // while t is greater than 0. We want to keep animating until our value reaches 0.
        {
            t -= Time.deltaTime * 4f; // While in IEnumerator, we can control our timing with our fading sequence. we can skip or wait a frame.
            float a = fadeCurve.Evaluate(t); // evaluate the time value with the curve of the fade.

            // img color.a = t; - can't modify Alpha color specifically through direct approach.
            img.color = new Color(0f, 0f, 0f, a); // new color (Red, Green, Blue, Alpha) , changed Alpha value to be our t. and it will change over the course of 1 second.
            yield return 0; // skip to the next frame. wait a frame and then continue
        }
    }

    IEnumerator FadeOut(int scene)
    {
        float t = 0f;
        while(t < 1)
        {
            t += Time.deltaTime * 4f;
            float a = fadeCurve.Evaluate(t);

            img.color = new Color(0f, 0f, 0f, 255f);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }

}
