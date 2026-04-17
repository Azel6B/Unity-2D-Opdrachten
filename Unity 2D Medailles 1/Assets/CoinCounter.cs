using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // Voor UI Text

public class CoinCounter : MonoBehaviour
{
    [Header("Coin Instellingen")]
    public int requiredCoins = 10;  // Aantal coins nodig om te winnen
    private int currentCoins = 0;

    [Header("UI")]
    public Text coinText;            // Sleep een UI Text element hierin
    public GameObject endScreenPanel; // Sleep het eindscherm panel hierin
    public Text endScreenMessage;     // Optioneel: tekst in eindscherm

    void Start()
    {
        UpdateCoinUI();

        // Zorg dat eindscherm uit staat bij start
        if (endScreenPanel != null)
            endScreenPanel.SetActive(false);

        // Pauzeer het spel niet bij start
        Time.timeScale = 1f;
    }

    public void AddCoins(int amount)
    {
        currentCoins += amount;
        UpdateCoinUI();

        Debug.Log($"Coins: {currentCoins}/{requiredCoins}");

        // Check of we gewonnen hebben
        if (currentCoins >= requiredCoins)
        {
            WinGame();
        }
    }

    void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = $"Coins: {currentCoins}/{requiredCoins}";
        }
    }

    void WinGame()
    {
        Debug.Log("GEWONNEN! Alle coins verzameld!");

        // Pauzeer het spel (optioneel)
        Time.timeScale = 0f;

        // Toon eindscherm
        if (endScreenPanel != null)
        {
            endScreenPanel.SetActive(true);

            if (endScreenMessage != null)
            {
                endScreenMessage.text = $"Je hebt gewonnen!\n{currentCoins} coins verzameld!";
            }
        }
    }

    // Methode voor een "Speel opnieuw" knop
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Methode voor "Terug naar menu" knop
    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // Vervang met jouw menunaam
    }
}