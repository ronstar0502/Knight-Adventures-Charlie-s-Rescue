using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    const string _playerTag = "Player";
    private int _currentLevelIndex;
    private GameObject[] _totalCoinsInLevel;
    [SerializeField] private GameObject victoryPanel;

    private void Awake()
    {
        victoryPanel.SetActive(false);
        _totalCoinsInLevel = GameObject.FindGameObjectsWithTag("Collectable");
        PlayerPrefs.SetInt("coins", 0);
        print("total coins in level: "+_totalCoinsInLevel.Length);
    }
    void Start()
    {
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        SaveLastLevel(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int playerCoins = PlayerPrefs.GetInt("coins");
        if (collision.gameObject.CompareTag(_playerTag) && playerCoins == _totalCoinsInLevel.Length)
        {
            if (_currentLevelIndex == SceneManager.sceneCountInBuildSettings - 1)
            {
                victoryPanel.SetActive(true);
                //SceneManager.LoadScene(0);
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

    public int GetTotalCoinsInLevel()
    {
        return _totalCoinsInLevel.Length;
    }
}
