using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallScript : MonoBehaviour
{
    public float speed = 10f;
    private float initialSpeed;
    private Rigidbody2D rigidBody;
    public float maxBounceAngle = 75f;
    public float speedIncreasePerBounce = 25.0f;

    private Vector2 initialVelocity;
    private Vector2 initialPosition;

    public UnityEvent<Collision2D> OnBlockHit;
    public UnityEvent<Collision2D> OnBottomBoundHit;

    private bool isWaitingForLaunch = true;
    public GameObject slider;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        initialSpeed = speed;
        initialVelocity = new Vector2(Random.Range(-25.0f, 25.0f), initialSpeed);
        initialPosition = transform.position;

        if (OnBlockHit == null)
        {
            OnBlockHit = new UnityEvent<Collision2D>();
        }
        if (OnBottomBoundHit == null)
        {
            OnBottomBoundHit = new UnityEvent<Collision2D>();
        }

        ResetBallToSlider();
    }

    private void Update()
    {
        if (isWaitingForLaunch)
        {
            StickToSlider();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                LaunchBall();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slider"))
        {
            BounceOffSlider(collision);
        }
        else if (collision.gameObject.CompareTag("Block"))
        {
            Debug.Log("Collision with block");
            OnBlockHit.Invoke(collision);
            BounceOffBlock(collision);
        }
        else if (collision.gameObject.CompareTag("Bound"))
        {
            Debug.Log("Collision with bound");
            BounceOffBound(collision);
        }
        else if (collision.gameObject.CompareTag("BottomBound"))
        {
            Debug.Log("Death");
            OnBottomBoundHit.Invoke(collision);
            ResetBallToSlider();
        }
        else if (collision.gameObject.CompareTag("PowerUp"))
        {
            Debug.Log("Collision with up");
            BounceOffBlock(collision);
        }

        IncreaseSpeed();
    }

    private void StickToSlider()
    {
        Vector2 sliderPosition = slider.transform.position;
        transform.position = new Vector2(sliderPosition.x, sliderPosition.y + 10f);
    }

    private void LaunchBall()
    {
        rigidBody.velocity = initialVelocity;
        isWaitingForLaunch = false;
    }

    private void ResetBallToSlider()
    {
        speed = initialSpeed;
        rigidBody.velocity = Vector2.zero;
        transform.position = slider.transform.position; 
        isWaitingForLaunch = true;

        initialVelocity = new Vector2(Random.Range(-25.0f, 25.0f), initialSpeed);
    }

    private bool RectOverlaps(RectTransform rect1, RectTransform rect2)
    {
        return rect1.rect.Overlaps(rect2.rect);
    }

    private void BounceOffSlider(Collision2D collision)
    {

        Vector2 ballPosition = transform.position;
        Vector2 sliderPosition = collision.transform.position;
        float paddleWidth = collision.collider.bounds.size.x;

        float offset = (ballPosition.x - sliderPosition.x) / (paddleWidth / 2);

        Vector2 direction = new Vector2(offset, 1f); 

        direction = direction.normalized;

    
        rigidBody.velocity = direction * speed;

        transform.position = new Vector2(transform.position.x, transform.position.y + 0.1f);
    }

    private void BounceOffBlock(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);

        Vector2 newVelocity = Vector2.Reflect(rigidBody.velocity, contact.normal).normalized * speed;

        if (newVelocity.magnitude < 0.1f)
        {
            newVelocity = newVelocity.normalized * speed;
        }

        rigidBody.velocity = newVelocity;
    }

    private void BounceOffBound(Collision2D collision)
    {
        ContactPoint2D contact = collision.GetContact(0);

        Vector2 newVelocity = Vector2.Reflect(rigidBody.velocity, contact.normal).normalized * speed;

        if (newVelocity.magnitude < 0.1f)
        {
            newVelocity = newVelocity.normalized * speed;
        }

        rigidBody.velocity = newVelocity;
    }

    private void IncreaseSpeed()
    {
        speed = speed + speedIncreasePerBounce;
        rigidBody.velocity = rigidBody.velocity.normalized * speed;
    }

}
