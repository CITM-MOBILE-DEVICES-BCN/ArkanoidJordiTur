using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusController : MonoBehaviour
{
    public void StartGameButton()
    {
        GameplayManagerScript.Instance.ResetPlayerLives();
        GameplayManagerScript.Instance.ResetPlayerScore();
        GameplayManagerScript.Instance.ResetPlayerLevel();
        SceneManager.Instance.LoadNextLevel();
    }

    public void ContinueButton()
    {
        if (GameplayManagerScript.Instance.savedGame == true)
        {
            GameplayManagerScript.Instance.LoadData();
            SceneManager.Instance.LoadNextLevel();
        }
        else
        {
            Debug.Log("No saved game data found.");
        }
    }

    public void ContinueToNextLevelButton()
    {
        SceneManager.Instance.WinLevel();
        SceneManager.Instance.LoadNextLevel();
    }

    public void SaveAndMainMenuButton()
    {
        GameplayManagerScript.Instance.SaveData();
        SceneManager.Instance.LoadMainMenu();
    }

    public void MainMenuButton()
    {
        SceneManager.Instance.LoadMainMenu();
    }
}
