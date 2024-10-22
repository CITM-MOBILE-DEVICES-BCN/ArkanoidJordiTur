using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI highScoreText;

    public void UpdatePoints(int points)
    {
        pointsText.text = "Points: " + points;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    public void UpdateHighScore(int highScore)
    {
        highScoreText.text = "High Score: " + highScore;
    }
}
