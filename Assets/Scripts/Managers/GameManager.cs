using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private Transform playerStart;
    [SerializeField] private GameObject defeatPanel;
    private PlayerData player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerData>();
        player.SetStartingLevelPosition(playerStart.position);
        defeatPanel.SetActive(false);
    }

    private void Start()
    {
        SetScoreText();
    }
    void Update()
    {
        SetScoreText();
        if (player.isDead && !defeatPanel.activeInHierarchy)
        {
            defeatPanel.SetActive(true);
        }
    }

    private void SetScoreText()
    {
        int coins = PlayerPrefs.GetInt("coins");
        int coinsTarget = FindObjectOfType<LevelPortalManager>().GetTotalCoinsInLevel();
        coinsText.text = $" : {coins}  /  {coinsTarget}";
    }

}
