using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

[System.Serializable]
public class GameplayManagerScript : MonoBehaviour
{
    public static GameplayManagerScript Instance { get; private set; }

    public int playerLives;
    public int playerScore;
    public int highScore;
    public int currentLevel;
    public bool savedGame;

    private string saveFilePath;

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

        saveFilePath = Path.Combine(Application.persistentDataPath, "gameData.json");
    }

    void Start()
    {
        LoadData();
    }

    void Update()
    {
       
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData
        {
            playerLivesJson = playerLives,
            playerScoreJson = playerScore,
            highScoreJson = highScore,
            currentLevelJson = currentLevel
        };

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        savedGame = true;
        Debug.Log("Game Data Saved to: " + saveFilePath);
    }

    public void LoadData()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerLives = data.playerLivesJson;
            playerScore = data.playerScoreJson; 
            highScore = data.highScoreJson;
            currentLevel = data.currentLevelJson;

            Debug.Log("Game Data Loaded from: " + saveFilePath);
        }
        else
        {
            playerLives = 3;
            playerScore = 0;
            highScore = 0;
            currentLevel = 1;
        }
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

    public void ResetPlayerLevel()
    {
        currentLevel = 1;
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
