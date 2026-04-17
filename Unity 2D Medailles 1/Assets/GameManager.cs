using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // Voor restarten

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Reference")]
    public TextMeshProUGUI scoreText;

    [Header("Win Conditie")]
    [SerializeField] private int requiredCoins = 10;   // Aantal coins nodig om te winnen
    [SerializeField] private GameObject endScreenPanel; // Sleep je eindscherm Panel hierin (met TMP tekst)

    private int currentScore = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
        if (endScreenPanel != null)
            endScreenPanel.SetActive(false);
        Time.timeScale = 1f; // Zeker dat spel draait
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

    // Nieuwe methode: check of winconditie is bereikt
    public void CheckWinCondition()
    {
        if (currentScore >= requiredCoins)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        Debug.Log($"GEWONNEN! {currentScore}/{requiredCoins} coins verzameld!");
        Time.timeScale = 0f; // Pauzeer het spel

        if (endScreenPanel != null)
        {
            endScreenPanel.SetActive(true);
            // Optioneel: update een TMP tekst in het panel
            TextMeshProUGUI winText = endScreenPanel.GetComponentInChildren<TextMeshProUGUI>();
            if (winText != null)
            {
                winText.text = $"Je hebt gewonnen!\n{currentScore} coins verzameld!";
            }
        }
    }

    // Methode voor een "Opnieuw" knop
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}