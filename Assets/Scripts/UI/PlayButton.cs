using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void PlayGame()
    {
        if (PlayerPrefs.HasKey("last_level"))
        {
            LoadLastScene();
        }
        else
        {
            SceneManager.LoadScene("Level_1");
        }
    }

    private void LoadLastScene()
    {
        string sceneToLoad = PlayerPrefs.GetString("last_level");

        Scene scene = SceneManager.GetSceneByName(sceneToLoad);
        Scene lastScene = SceneManager.GetSceneByBuildIndex(SceneManager.sceneCountInBuildSettings - 1);
        
        if (scene == lastScene)
        {
            SceneManager.LoadScene("Level_1");
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
