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

    void Update()
    {
        scoreText.text = $"Score: {player.score}";
    }
}
