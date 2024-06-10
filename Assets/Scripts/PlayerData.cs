using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public void SaveLasLevel(string level)
    {
        PlayerPrefs.SetString("last_level",level);
        PlayerPrefs.Save();
    }
    public void SaveScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.Save();
    }
}
