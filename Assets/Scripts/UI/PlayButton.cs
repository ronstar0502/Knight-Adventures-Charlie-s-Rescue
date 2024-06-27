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

    public void PlayNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level_1");
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
        string isLastLevelComlete = PlayerPrefs.GetString("isLevelComplete");
        print(sceneIndex+"/"+lastSceneIndex);
        
        if (sceneIndex == lastSceneIndex && isLastLevelComlete == "Yes")
        {           
            SceneManager.LoadScene("Level_1");
        }
        else
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
