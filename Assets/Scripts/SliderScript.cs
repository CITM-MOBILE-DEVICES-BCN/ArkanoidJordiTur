using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 originalMousePosition;

    public EventSystem eventSystem;
    private PointerEventData pointerEventData;
    private GraphicRaycaster rayCaster;

    private bool isAutomatic = false;
    private float speed = 1500f;
    private float direction = 1f;

    public UIManager uiManager;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        rayCaster = GetComponentInParent<Canvas>().GetComponent<GraphicRaycaster>();

        pointerEventData = new PointerEventData(eventSystem);

    }

    void Update()
    {
        HandleToggleAutomatic();

        if (isAutomatic)
        {
            HandleAutomaticMovement();
        }
        else
        {
            HandleManualDragging();
        }
    }

    private void HandleToggleAutomatic()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isAutomatic = !isAutomatic;  
        }
    }

    private void HandleManualDragging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsPointerOverUIObject())
            {
                isDragging = true;

                originalMousePosition = Input.mousePosition;

                offset = rectTransform.anchoredPosition;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector2 newMousePosition = GetMouseCanvasPosition();

            rectTransform.anchoredPosition = new Vector2(newMousePosition.x + offset.x, rectTransform.anchoredPosition.y);
        }
    }

    private void HandleAutomaticMovement()
    {
        float newXPosition = rectTransform.anchoredPosition.x + direction * speed * Time.deltaTime;

        float canvasWidth = canvas.GetComponent<RectTransform>().rect.width;
        float sliderWidth = rectTransform.rect.width;

        if (newXPosition > canvasWidth / 2 - sliderWidth / 2)
        {
            newXPosition = canvasWidth / 2 - sliderWidth / 2;
            direction = -1f;
        }

        else if (newXPosition < -canvasWidth / 2 + sliderWidth / 2)
        {
            newXPosition = -canvasWidth / 2 + sliderWidth / 2;
            direction = 1f;
        }

        rectTransform.anchoredPosition = new Vector2(newXPosition, rectTransform.anchoredPosition.y);
    }

    private bool IsPointerOverUIObject()
    {
        pointerEventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        rayCaster.Raycast(pointerEventData, results);
        
        foreach (RaycastResult result in results)
        {
            if (result.gameObject == gameObject)
            {
                return true;
            }
        }

        return false;
    }

    private Vector2 GetMouseCanvasPosition()
    {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 localPoint;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out localPoint);
        return localPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PowerUp"))
        {
            AudioManager.Instance.PlaySound("PowerUp");
            Debug.Log("Lives: " + GameplayManagerScript.Instance.playerLives);
            if (uiManager != null)
            {
                uiManager.UpdateLives(GameplayManagerScript.Instance.playerLives);
            }
        }
    }
}
