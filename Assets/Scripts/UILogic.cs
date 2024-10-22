using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILogic : MonoBehaviour
{
    public UIManager uiManager;

    void Start()
    {
        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in scene");
        }
        else
        {
            uiManager.UpdateLives(GameplayManagerScript.Instance.playerLives);
            uiManager.UpdatePoints(GameplayManagerScript.Instance.playerScore);
            uiManager.UpdateHighScore(GameplayManagerScript.Instance.highScore);
        }
    }

    private void Update()
    {
        UpdateHighScore();
    }

    void UpdateHighScore()
    {
        if (GameplayManagerScript.Instance.playerScore > GameplayManagerScript.Instance.highScore)
        {
            GameplayManagerScript.Instance.highScore = GameplayManagerScript.Instance.playerScore;
            if (uiManager != null)
            {
                uiManager.UpdateHighScore(GameplayManagerScript.Instance.highScore);
            }
        }
    }
}
