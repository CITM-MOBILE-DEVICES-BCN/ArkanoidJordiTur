using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenusController : MonoBehaviour
{
    public void StartGameButton()
    {
        GameplayManagerScript.Instance.ResetPlayerLives();
        GameplayManagerScript.Instance.ResetPlayerScore();
        SceneManager.Instance.LoadNextLevel();
    }

    public void ContinueButton()
    {

    }

    public void ContinueToNextLevelButton()
    {
        SceneManager.Instance.WinLevel();
        SceneManager.Instance.LoadNextLevel();
    }

    public void MainMenuButton()
    {
        SceneManager.Instance.LoadMainMenu();
    }
}
