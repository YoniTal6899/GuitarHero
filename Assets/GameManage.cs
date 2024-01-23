// GameManager.cs

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public int lives = 3; // Set the initial number of lives in the Unity Editor
    public int hitsToWin = 20; // Set the number of hits required to win in the Unity Editor

    private int currentHits = 0;
    private int currentStreak=0;

    public TextMeshPro livesText;
    public TextMeshPro hitsText;
    public TextMeshPro streakText;

    void Start()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        livesText.text = "Lives: " + lives;
        hitsText.text = "Hits: " + currentHits;
        streakText.text= "Streak: "+ currentStreak;
    }

    public void LoseLife()
    {
        lives--;
        currentStreak=0;

        UpdateUI();
        // Check if the player has run out of lives
        if (lives <= 0)
        {
            GameOver();
        }
    }

    public void IncreaseHits()
    {
        currentHits++;
        currentStreak+=1;

       UpdateUI();

        // Check if the player has reached the required hits to win
        if (currentHits >= hitsToWin)
        {
            GameWon();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene("DefeatScene");
    }

    void GameWon()
    {
        Debug.Log("Game Won!");
        SceneManager.LoadScene("VictoryScene");
    }
}
