using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private Transform playerStart;
    private PlayerData player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerData>();
    }

    private void Start()
    {
        player.SetStartingLevelPosition(playerStart.position);
        SetScoreText();
    }
    void Update()
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        int coins = PlayerPrefs.GetInt("coins");
        int coinsTarget = FindObjectOfType<LevelPortal>().GetTotalCoinsInLevel();
        coinsText.text = $"Coins: {coins}  /  {coinsTarget}";
    }

}
