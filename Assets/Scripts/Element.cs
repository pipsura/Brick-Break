using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "Element", menuName = "ScriptableObjects/Element", order = 1)]
public class Element : ScriptableObject
{
    public Element Parent;
    public int Health= 0;
    public int Score = 0;


    private void OnEnable()
    {
        if (Parent == null) return;
        if (Health == 0) Health = Parent.Health;
        if (Score == 0) Score = Parent.Score;
    }
}
