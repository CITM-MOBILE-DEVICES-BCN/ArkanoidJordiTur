using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance { get; private set; }

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

    private void Start()
    {
        
    }

    private void Update()
    {
   
    }

    public void WinLevel()
    {
        string thisLevel = GetCurrentLevel();

        if (thisLevel == "SampleScene")
        {
            GameplayManagerScript.Instance.currentLevel = 2;
        }
        else if (thisLevel == "Level2")
        {
            GameplayManagerScript.Instance.currentLevel = 1;
        }

        LoadWinScreen();
    }   

    public void LoadNextLevel()
    {
        if (GameplayManagerScript.Instance.currentLevel == 1)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        }
        else if (GameplayManagerScript.Instance.currentLevel == 2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
        }
    }

    public void LoadWinScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScreen");
    }

    public void LoadLoseScreen()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LoseScreen");
    }

    public void LoadMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public string GetCurrentLevel()
    {
        return UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

}
