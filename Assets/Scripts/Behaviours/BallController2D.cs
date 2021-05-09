using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController2D : MonoBehaviour
{

    private Rigidbody2D rigidbody;
    public Transform paddle;
    public bool inPlay;

    public GameManager gameManager;

    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (gameManager.gameOver)
        {
            return;
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !inPlay)
        {
            inPlay = true;
            rigidbody.AddForce(Vector2.up * moveSpeed);
        }
        if (!inPlay)
        {
            transform.position = paddle.position;
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            Debug.Log("Ball hit bottom of screen");
            rigidbody.velocity = Vector2.zero;
            inPlay = false;
            gameManager.UpdateLives(-1);
        }

    }

    


}
