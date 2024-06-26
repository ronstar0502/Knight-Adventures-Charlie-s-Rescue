using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    PlayerData playerData;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private TextMeshProUGUI healthBarText;

    private void Start()
    {
        playerData = FindObjectOfType<PlayerData>();
        UpdateHealthBar();
    }
    void Update()
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float playerHP = playerData.GetHealth();
        float playerMaxHP = playerData.GetMaxHealth();
        float targetFillAmount = playerHP / playerMaxHP;
        healthBarFill.fillAmount = targetFillAmount;
        healthBarText.text = playerHP + "  /  " + playerMaxHP;
    }
}
