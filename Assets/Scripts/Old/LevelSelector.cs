using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;
    public LevelChanger levelChanger;

   public void Select(int levelName) // the functions takes in a string value with the level name that we want to select (Level name is displayed in the buttons)
    {
        fader.FadeTo(levelName);
    }

    public void SelectLevel(int levelIndex) 
    {
        SceneManager.LoadScene(levelIndex);
    }


}
