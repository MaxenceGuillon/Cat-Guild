using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName ="Cats/New cat")]

public class CatData : ScriptableObject
{
    public string nameOfCat;
    public Sprite visual;
    public string descriptionOfCat;


    // Stats of Cat

    public int moneyWin;

    public int charmingMin;
    public int procrastinatorMin;
    public int adventurousMin;

    public int charmingMax;
    public int procrastinatorMax;
    public int adventurousMax;
}

