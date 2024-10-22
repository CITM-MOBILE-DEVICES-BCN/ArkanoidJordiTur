using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour
{
    public float fallSpeed = 2.0f;
 
    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Slider"))
        {
            ApplyExtraLife();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("BottomBound"))
        {
            Destroy(gameObject);
        }
    }

    public void ApplyExtraLife()
    {
        GameplayManagerScript.Instance.playerLives++;
    }
}
