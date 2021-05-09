using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController2D : MonoBehaviour
{

    private Rigidbody2D rigidbody;

    [SerializeField] private float moveSpeed;

    private void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();

        rigidbody.AddForce(Vector2.up * moveSpeed);
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bottom"))
        {
            Debug.Log("Ball hit bottom of screen");
        }
    }

}
