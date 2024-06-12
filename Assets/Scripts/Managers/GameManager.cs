using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private PlayerController player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Start()
    {
        SetScoreText();
    }
    void Update()
    {
        SetScoreText();
    }

    private void SetScoreText()
    {
        scoreText.text = $"Score: {player.score}";
    }

}
