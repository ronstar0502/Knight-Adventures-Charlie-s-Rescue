using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    const string _playerTag = "Player";
    private int _currentLevelIndex;
    void Start()
    {
        _currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
        print("level build index: "+_currentLevelIndex);
        SaveLasLevel(SceneManager.GetActiveScene().name);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_playerTag))
        {
            if (_currentLevelIndex == SceneManager.sceneCountInBuildSettings-1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                print(_currentLevelIndex+1);
                SceneManager.LoadScene(_currentLevelIndex+1);
            }
        }
    }

    public void SaveLasLevel(string level)
    {
        PlayerPrefs.SetString("last_level", level);
        print("last level name: "+PlayerPrefs.GetString("last_level"));
        PlayerPrefs.Save();
    }
}
