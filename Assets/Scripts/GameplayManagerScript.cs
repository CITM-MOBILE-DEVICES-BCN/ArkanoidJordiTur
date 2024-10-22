using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManagerScript : MonoBehaviour
{
    public static GameplayManagerScript Instance { get; private set; }

    public int playerLives = 3;
    public int playerScore = 0;
    public int highScore = 0;
    public int currentLevel = 1;

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
