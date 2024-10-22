using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    public BallScript ball;
    public UIManager uiManager;

    void Start()
    {
        if (ball == null)
        {
            Debug.LogError("Ball not found in scene");
        }
        else
        {
            ball.OnBlockHit.AddListener(OnBlockHit);
            ball.OnBottomBoundHit.AddListener(OnBottomBoundHit);
        }
    }
    
    void OnBlockHit(Collision2D collision)
    {
        BlockScript block = collision.gameObject.GetComponent<BlockScript>();
        if (block != null)
        {
            block.TakeHit();
        }

    }

    void OnBottomBoundHit(Collision2D collision)
    {
        if (ball != null)
        {
            GameplayManagerScript.Instance.playerLives--;
            Debug.Log("Lives: " + GameplayManagerScript.Instance.playerLives);
            if (uiManager != null)
            {
                uiManager.UpdateLives(GameplayManagerScript.Instance.playerLives);
            }
        }

        if (GameplayManagerScript.Instance.playerLives <= 0)
        {
            Debug.Log("Game Over");
            LostGame();
            GameplayManagerScript.Instance.ResetPlayerLives();
            GameplayManagerScript.Instance.ResetPlayerScore();
        }
    }

    void LostGame()
    {
        if (GameplayManagerScript.Instance.playerLives <= 0)
        {
            SceneManager.Instance.LoadLoseScreen();
        }
    }
}
