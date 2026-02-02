using UnityEngine;
using TMPro; // Make sure you have TextMeshPro installed

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Reference")]
    public TextMeshProUGUI scoreText;

    private int currentScore = 0;

    void Awake()
    {
        // Singleton pattern so the coin can find the manager easily
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
        UpdateScoreUI();
        Debug.Log($"Score increased! Total: {currentScore}");
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {currentScore}";
        }
    }
}
