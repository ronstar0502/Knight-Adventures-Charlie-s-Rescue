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
                PlayerPrefs.SetInt("coins",0);
                FindObjectOfType<PlayerData>().SaveCoinsData();
                SceneManager.LoadScene(_currentLevelIndex + 1);
            }
        }
    }

    public void SaveLastLevel(string level)
    {
        PlayerPrefs.SetString("last_level", level);
        PlayerPrefs.Save();
    }    
}
