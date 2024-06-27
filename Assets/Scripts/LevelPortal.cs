using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    const string _playerTag = "Player";
    private int _currentLevelIndex;

    void Start()
    {
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        print("active scene index: " + _currentLevelIndex);
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
                PlayerPrefs.Save();
                print("coins: " + PlayerPrefs.GetInt("coins"));
                SceneManager.LoadScene(_currentLevelIndex + 1);
            }
        }
    }

    
}
