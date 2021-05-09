using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController2D : MonoBehaviour
{

    [SerializeField] private Element myElement;
    [SerializeField] private int Health;

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
        Destroy(gameObject);
    }

}
