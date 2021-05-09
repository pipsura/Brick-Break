using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController2D : MonoBehaviour
{

    [SerializeField] private Element myElement;
    [SerializeField] private int Health;

    public GameManager gameManager;

    void Start()
    {
        Health = myElement.Health;
    }


    void TakeDamage()
    {
        Health--;
        if (Health <= 0)
        {
            OnBreak();
        }
    }

    void OnBreak()
    {
        Debug.Log("Block destroyed");
        gameManager.UpdateScore(myElement.Score);
        gameManager.UpdateNumberOfBricks();
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            Debug.Log("Damage");
            TakeDamage();
        }
    }

}
