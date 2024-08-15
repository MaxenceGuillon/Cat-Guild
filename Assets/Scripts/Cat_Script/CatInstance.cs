using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]

// In Cat Guild you can have many instances of the same cat specie 
public class CatInstance : ScriptableObject
{
    public CatData cat; // Cat specie choose

    // Cat instance stats
    public int charming;
    public int procrastinator;
    public int adventurous;

    public int alphaStat;
    public int betaStat;
    public int omegaStat;
}
