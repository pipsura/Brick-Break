using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController2D : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private float finalSpeed;

    public float rightScreenEdge;
    public float leftScreenEdge;

    public GameManager gameManager;

    private Rigidbody2D rigidbody;
    private Vector2 myVelocity;
    private Vector2 currentInputDirection;

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
        Move(currentInputDirection);
    }

    public void Move(Vector2 direction)
    {
        CheckEdgeMovement();
        myVelocity = rigidbody.velocity;
        myVelocity.x = direction.x * finalSpeed;
        rigidbody.velocity = myVelocity;
    }

    private void CheckEdgeMovement()
    {
        if (transform.position.x <= leftScreenEdge && currentInputDirection == Vector2.left)
        {
            finalSpeed = 0;

        }
        else if (transform.position.x >= rightScreenEdge && currentInputDirection == Vector2.right)
        {
            finalSpeed = 0;

        }
        else
        {
            finalSpeed = moveSpeed;
        }
    }

    public void OnMove(InputValue input)
    {
        currentInputDirection = input.Get<Vector2>();
    }

}
