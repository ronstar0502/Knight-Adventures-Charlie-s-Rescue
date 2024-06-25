using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelPortalManager : MonoBehaviour
{
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private GameObject victoryPanel;
    private GameObject[] _totalCoinsInLevel;

    private void Awake()
    {
        victoryPanel.SetActive(false);
    }
    private void Start()
    {
        _totalCoinsInLevel = GameObject.FindGameObjectsWithTag("Collectable");
        PlayerPrefs.SetInt("coins", 0);
    }

    public void CheckIsLevelComplete()
    {
        int playerCoins = PlayerPrefs.GetInt("coins");
        if (playerCoins == _totalCoinsInLevel.Length)
        {
            Instantiate(portalPrefab, transform.position, Quaternion.identity);
        }
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
