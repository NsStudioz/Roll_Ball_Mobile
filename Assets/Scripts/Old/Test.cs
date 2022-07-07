using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Test : MonoBehaviour
{

    public int currentSceneIndex;
    private int[] triggerValues = { 12, 22, 32, 42, 52 };


    public void FadeToMainMenu()
    {
        if (currentSceneIndex == 12 || currentSceneIndex == 22
            || currentSceneIndex == 32 || currentSceneIndex == 42
            || currentSceneIndex == 52)
        {
            /*            AdManager.Instance.ShowAd(this);*/
        }
    }

    public void blyatFadeToMainMenu()
    {
        if (triggerValues.Contains(currentSceneIndex))
        {
/*            AdManager.Instance.ShowAd(this);*/
        }
    }
}
