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
        print("scene to load: "+sceneToLoad);
        //Scene scene = SceneManager.GetSceneByName(sceneToLoad);
        //Scene lastScene = SceneManager.GetSceneByBuildIndex(SceneManager.sceneCountInBuildSettings - 1);
        //int sceneIndex = SceneManager.GetSceneByName(sceneToLoad).buildIndex; //error
        int sceneIndex = SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/" + sceneToLoad + ".unity"); //finding the scene build index from the path of the scene
        int lastSceneIndex = SceneManager.sceneCountInBuildSettings - 1;
        print(sceneIndex+"/"+lastSceneIndex);
        if (sceneIndex == lastSceneIndex)
        {
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene("Level_1");
        }
        else
        {
            PlayerPrefs.SetInt("score", 0);
            FindObjectOfType<PlayerData>().SaveCoinsData(0);
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
