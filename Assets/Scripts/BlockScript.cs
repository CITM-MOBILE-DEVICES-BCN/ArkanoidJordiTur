using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockScript : MonoBehaviour
{
    public int resistance = 0;
    public int points = 0;
    private RectTransform rectTransform;
    private BlockManager blockManager;
    public GameObject powerUpPrefab;
    public float dropRate = 0.03f;

    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        blockManager = FindObjectOfType<BlockManager>();
        canvas = FindObjectOfType<Canvas>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            TakeHit();
        }
    }

    public void TakeHit()
    {
        resistance--;
        if (resistance<=0)
        {
            DestroyBlock();
        }
    }

    private void AdjustSizeToScreen()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        float widthScale = screenWidth / 1920;
        float heightScale = screenHeight / 1080;    

        Vector2 newSize = new Vector2(100 * widthScale, 50 * heightScale);
        rectTransform.sizeDelta = newSize;
    }

    protected virtual void DestroyBlock()
    {
        if (blockManager != null)
        {
            blockManager.OnBlockDestroyed(this);
        }
        DropPowerUp();
        Destroy(gameObject);
    }

    private void DropPowerUp()
    {
        if (powerUpPrefab != null && Random.value <= dropRate)
        {
            GameObject powerUpInstance = Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
            powerUpInstance.transform.SetParent(canvas.transform, false);
        }
    }
}


