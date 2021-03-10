using UnityEngine;

public enum CoinTypes
{
    DefaultCoin = 1,
    DoubleCoin = 2,
    MaxiCoin = 10,
    UltraCoin = 100
}
public class PlayerCoins : MonoBehaviour
{
    public static PlayerCoins Instance;
    public int CollectedCoins;

    private void Start()
    {
        Instance = this;
    }

    public void AddCoins(int valueToAdd)
    {
        CollectedCoins += valueToAdd;
        ScoreScript.Instance.SetCoinsText(CollectedCoins);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            int coinValue = (int)other.GetComponent<CoinScript>().CoinType;
            AddCoins(coinValue);
        }
    }

    public int LoadCoins()
    {
        return PlayerPrefs.GetInt("PlayerCoins", 0); 
    }

    public void SaveCoins()
    {
        int playerCoins = PlayerPrefs.GetInt("PlayerCoins", 0);
        playerCoins += CollectedCoins;
        PlayerPrefs.SetInt("PlayerCoins", playerCoins);
    }
}
