using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName ="Cats/New cat")]

public class CatData : ScriptableObject
{
    public string nameOfCat;
    public Sprite visual;
    public string descriptionOfCat;
}

[System.Serializable]
public class CatID
{
    public CatData nameOfCat;
    public int id;
}

