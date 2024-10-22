using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicScreenBoundaries : MonoBehaviour
{
    public RectTransform rightBound;
    public RectTransform leftBound;
    public RectTransform topBound;
    public float baseBoundWidth = 100f;
    public float baseTopBoundHeight = 50f;

    private Canvas canvas;
    private RectTransform canvasRect;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();

        UpdateBounds();
    }

    private void Update()
    {
        UpdateBounds();
    }

    void UpdateBounds()
    {
        float screenWidth = canvasRect.rect.width;
        float screenHeight = canvasRect.rect.height;

        float aspectRatio = screenWidth / screenHeight; 
        float adjustedBoundWidth = baseBoundWidth * aspectRatio;
        float dynamicYSize = screenHeight;

        SetBoundPositionAndSize(leftBound, -screenWidth / 2 + adjustedBoundWidth / 2, screenHeight, dynamicYSize);
        SetBoundPositionAndSize(rightBound, screenWidth / 2 - adjustedBoundWidth / 2, screenHeight, dynamicYSize);
    }

    void SetBoundPositionAndSize(RectTransform bound, float width, float height, float x)
    {
        bound.anchorMin = new Vector2(0, 0);
        bound.anchorMax = new Vector2(0, 1);
        bound.pivot = new Vector2(0.5f, 0.5f);

        bound.anchoredPosition = new Vector2(x, 0);
        bound.sizeDelta = new Vector2(width, height);
    }
}
