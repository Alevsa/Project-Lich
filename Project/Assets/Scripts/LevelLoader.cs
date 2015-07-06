using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {


    public void LoadLevel(string levelToLoad)
    {
        Application.LoadLevel(levelToLoad);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
