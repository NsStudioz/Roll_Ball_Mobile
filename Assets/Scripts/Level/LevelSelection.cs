using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{

    public Button[] lvlButtons;

    [SerializeField] private int LevelSelectSceneIndexOffset = 2;

    void Start()
    {
        InitializeButtonInteractability();
        InitializeButtonToLevelSelectIndex();
    }

    private void InitializeButtonInteractability()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 3);

        for (int i = 0; i < lvlButtons.Length; i++)
        {
            if (i + 3 > levelAt)
            {
                lvlButtons[i].interactable = false;
            }
        }
    }

    private void InitializeButtonToLevelSelectIndex()
    {
        for (int n = 0; n < lvlButtons.Length; n++)
        {
            if (lvlButtons[n].interactable)
            {
                int currentSceneIndex = n + LevelSelectSceneIndexOffset;
                lvlButtons[n].onClick.AddListener(() => { TriggerFadeToLevel(currentSceneIndex); });
            }
        }
    }

    private void TriggerFadeToLevel(int currentSceneIndex)
    {
        GameEvents.OnLevelSelected?.Invoke(currentSceneIndex);
    }

}
