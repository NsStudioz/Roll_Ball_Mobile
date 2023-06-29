using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Handler : MonoBehaviour
{
    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Play_()
    {
        AudioManager.Instance.Play("");
    }

    #region Player_Functions

    private void Play_PlayerJump()
    {
        AudioManager.Instance.Play("");
    }


    #endregion


}
