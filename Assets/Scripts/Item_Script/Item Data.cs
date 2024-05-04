using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New Item")]

public class ItemData : ScriptableObject
{
    public string nameItem;
    public Sprite visualItem;
    public string priceUI;
    public int buyingPrice;
    public int sendingPrice;
    public bool inMarket = false;
    public int expAdd;

}

