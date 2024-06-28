using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelsButtons : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void RestartLevel()
    {
        string currentLevelName = PlayerPrefs.GetString("last_level");
        print("current level reload: "+currentLevelName);
        SceneManager.LoadScene(currentLevelName);
    }

    private void OnMouseEnter()
    {
        print("hello click");
    }
}
