using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDeleter : MonoBehaviour
{

#if UNITY_EDITOR
    void Update()
    {
        DeletePlayerData();
    }

    private void DeletePlayerData()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Player Prefs Has Been Successfully Deleted!");
        }
    }

#endif
}
