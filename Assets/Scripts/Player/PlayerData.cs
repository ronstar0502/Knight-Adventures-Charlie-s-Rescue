using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int _coins;
    private int _health;

    private void Start()
    {
        _coins = PlayerPrefs.GetInt("coins");
        _health = PlayerPrefs.GetInt("health");
        SaveMaxHealthData();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            _coins += coin.GetValue();
            SaveCoinsData();
            Destroy(coin.gameObject);
        }
    }

    private void SaveCoinsData()
    {
        PlayerPrefs.SetInt("coins", _coins);
        print("saved coins: " + PlayerPrefs.GetInt("coins"));
        PlayerPrefs.Save();
    }

    private void SaveHealthData()
    {
        PlayerPrefs.SetInt("health", _health);
        print("health: " + PlayerPrefs.GetInt("health"));
        PlayerPrefs.Save();
    }

    private void SaveMaxHealthData()
    {
        PlayerPrefs.SetInt("max_health", maxHealth);
        PlayerPrefs.Save();
    }

    public void TakeDamage(int damage)
    {
        if (_health - damage <= 0)
        {
            _health = 0;
            RestartLevel();
        }
        else
        {
            _health -= damage;
            SaveHealthData();
        }

    }

    private void RestartLevel()
    {
        _health = maxHealth;
        SaveHealthData();
        SceneManager.LoadScene(PlayerPrefs.GetString("last_level"));
    }

    public void SetStartingLevelPosition(Vector2 position)
    {
        transform.position = position;
    }

}
