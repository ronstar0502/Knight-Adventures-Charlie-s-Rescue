using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    const string _playerTag = "Player";
    private int _currentLevelIndex;

    void Start()
    {
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SaveLastLevel(SceneManager.GetActiveScene().name);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if (collision.gameObject.CompareTag(_playerTag))
        {
            if (_currentLevelIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                FindObjectOfType<LevelPortalManager>().EnableVictoryPanel();
                PlayerPrefs.DeleteAll();
            }
            else
            {
                print(_currentLevelIndex + 1);                
                SceneManager.LoadScene(_currentLevelIndex + 1);
            }
        }
        else
        {
            print("go get the other coins before going to next level");
        }
    }

    public void SaveLastLevel(string level)
    {
        PlayerPrefs.SetString("last_level", level);
        PlayerPrefs.Save();
    }    
}
