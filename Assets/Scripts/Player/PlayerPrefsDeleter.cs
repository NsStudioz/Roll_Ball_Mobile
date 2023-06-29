using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDeleter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Player Prefs Has Been Successfully Deleted!");
        }
    }
}
