using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static ScoreScript Instance;
    public Text HeightScoreTextBox;
    public Text CoinTextBox;
    public int TopScore;

    private void Start()
    {
        Instance = this;
    }

    void LateUpdate()
    {
        SetHeightScoreText();
    }

    public void SetCoinsText(int coins)
    {
        CoinTextBox.text = $"Coins: {coins}";
    }

    private void SetHeightScoreText()
    {
        int playerPos = Mathf.RoundToInt(PlayerController.Instance.transform.position.y);

        if (playerPos > TopScore)
        {
            TopScore = playerPos;
            HeightScoreTextBox.text = $"Score: {TopScore}";
        }
    }

    public void SaveScorePoints()
    {
        int currentMaxScore = PlayerPrefs.GetInt("MaxScore", 0);

        if (TopScore > currentMaxScore)
        {
            PlayerPrefs.SetInt("MaxScore",TopScore);
        }
    }
}
