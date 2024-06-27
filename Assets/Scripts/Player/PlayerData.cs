using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerData : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private Vector2 startingCheckpoint;
    private int _health;
    private int _coins;
    public bool isDead;

    private void Awake()
    {
        SaveMaxHealthData();
    }
    private void Start()
    {
        SetPlayerPosition();
        _coins = PlayerPrefs.GetInt("coins");
        SaveCoinsData();
        _health = maxHealth;
        SaveHealthData();
        isDead = false;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Coin coin = other.gameObject.GetComponent<Coin>();
            _coins += coin.GetValue();
            SaveCoinsData();
            Destroy(coin.gameObject);
            FindObjectOfType<LevelPortalManager>().CheckIsLevelComplete();
        }
    }

    public int GetHealth()
    {
        return _health;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public void SaveCoinsData()
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
            isDead = true;
        }
        else
        {
            _health -= damage;
            SaveHealthData();
        }
    }
    private void SetPlayerPosition()
    {
        transform.position = startingCheckpoint;
    }

    public void SetStartingLevelPosition(Vector2 position)
    {
        startingCheckpoint = position;
    }
    
    public Vector2 GetPlayerStartPosition()
    {
        return startingCheckpoint;
    }
    public void RestartLevel()
    {
        _health = maxHealth;
        SaveHealthData();
    }

}
