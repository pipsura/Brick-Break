using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController2D : MonoBehaviour
{

    [SerializeField] private Element myElement;
    [SerializeField] private int Health;

    public Sprite minorSprite;
    public Sprite majorSprite;

    public GameManager gameManager;


    void Start()
    {
        Health = myElement.Health;
    }

    public void TakeDamage()
    {
        Health--;
        if (Health <= 0)
        {

            OnBreak();
        } else
        {
            DamageBrick();
        }
    }

    public void OnBreak()
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

    public void DamageBrick()
    {
        if (Health > 1)
        {
            GetComponent<SpriteRenderer>().sprite = minorSprite;
        } else
        {
            GetComponent<SpriteRenderer>().sprite = majorSprite;
        }
    }


}
