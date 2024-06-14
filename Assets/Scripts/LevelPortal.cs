using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    const string _playerTag = "Player";
    private int _currentLevelIndex;
    private int _totalCoinsInLevel;

    private void Awake()
    {
        _totalCoinsInLevel = FindObjectsByType<Coin>(FindObjectsSortMode.None).Length;
        print("total coins in level: "+_totalCoinsInLevel);
    }
    void Start()
    {
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SaveLasLevel(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int playerCoins = PlayerPrefs.GetInt("coins");
        if (collision.gameObject.CompareTag(_playerTag) && playerCoins == _totalCoinsInLevel)
        {
            if (_currentLevelIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                print(_currentLevelIndex + 1);
                PlayerPrefs.SetInt("coins", 0);
                SceneManager.LoadScene(_currentLevelIndex + 1);
            }
        }
        else
        {
            print("go get the other coins before going to next level");
        }
    }

    public void SaveLasLevel(string level)
    {
        PlayerPrefs.SetString("last_level", level);
        PlayerPrefs.Save();
    }

    public int GetTotalCoinsInLevel()
    {
        return _totalCoinsInLevel;
    }
}
