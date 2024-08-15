using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName ="Cats/New cat")]

// Species of Cat
public class CatData : ScriptableObject
{
    // Mains Informations
    public string nameOfCat;
    public Sprite visual;
    public string descriptionOfCat;
    public int moneyWin;

    // Stats range of specie
    public int charmingMin;
    public int procrastinatorMin;
    public int adventurousMin;

    public int charmingMax;
    public int procrastinatorMax;
    public int adventurousMax;
}

