using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortalManager : MonoBehaviour
{
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private GameObject victoryPanel;
    private GameObject[] _totalCoinsInLevel;

    private void Awake()
    {
        victoryPanel.SetActive(false);
        PlayerPrefs.SetInt("coins", 0);
        PlayerPrefs.SetString("isLevelComplete", "No");
        PlayerPrefs.Save();
    }
    private void Start()
    {
        LevelNameInit();
        _totalCoinsInLevel = GameObject.FindGameObjectsWithTag("Collectable");
    }

    private void LevelNameInit()
    {
        int sceneName = SceneManager.GetActiveScene().buildIndex;
        print("scene index:" + sceneName);
        SaveLastLevel(SceneManager.GetActiveScene().name);
    }

    public void CheckIsLevelComplete()
    {
        int playerCoins = PlayerPrefs.GetInt("coins");
        if (playerCoins == _totalCoinsInLevel.Length)
        {
            PlayerPrefs.SetString("isLevelComplete","Yes");
            PlayerPrefs.Save();
            Instantiate(portalPrefab, transform.position, Quaternion.identity);
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

    public void EnableVictoryPanel()
    {
        victoryPanel.SetActive(true);
    }
}
