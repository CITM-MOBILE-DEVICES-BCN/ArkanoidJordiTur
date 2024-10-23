using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameplayManagerScript : MonoBehaviour
{
    public static GameplayManagerScript Instance { get; private set; }

    public int playerLives;
    public int playerScore;
    public int highScore;
    public int currentLevel;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        playerLives = 3;
        playerScore = 0;
        highScore = 0;
        currentLevel = 1;
    }

    void Update()
    {
     
    }

    public void ResetPlayerLives()
    {
        playerLives = 3;
    }

    public void IncreaseLives()
    {
        playerLives++;
    }

    public void ResetPlayerScore()
    {
        playerScore = 0;
    }

    public int GetPlayerLives()
    {
        return playerLives;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

}
