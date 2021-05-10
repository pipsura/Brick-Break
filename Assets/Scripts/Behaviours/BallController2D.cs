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

    AudioSource audioClip;

    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        audioClip = GetComponent<AudioSource>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Block"))
        {
            playAudio();
        }
    }

    public void playAudio()
    {
        Debug.Log("Audio called");
        audioClip.Play();
    }





}
