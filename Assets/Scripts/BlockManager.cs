using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public List<BlockScript> allBlocks;
    public UIManager uiManager;
    public GameObject powerUpPrefab;
    private int remainingBlocks;
    public float dropRate = 0.1f;

    void Start()
    {
        allBlocks = new List<BlockScript>(FindObjectsOfType<BlockScript>());
        remainingBlocks = allBlocks.Count;
    }

    public void OnBlockDestroyed(BlockScript block)
    {
        remainingBlocks--;
        GameplayManagerScript.Instance.playerScore += block.points;
        uiManager.UpdatePoints(GameplayManagerScript.Instance.playerScore);
        allBlocks.Remove(block);
        Debug.Log("Remaining blocks: " + remainingBlocks);

        if (remainingBlocks <= 0)
        {
            TriggerWinScreen();
        }
    }

    private void TriggerWinScreen()
    {
        SceneManager.Instance.WinLevel();
    }
}
