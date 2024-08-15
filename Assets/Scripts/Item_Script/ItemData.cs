using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Items/New Item")]

public class ItemData : ScriptableObject
{
    // Main informations
    public string nameItem;
    public Sprite visualItem;

    // Market informations
    public string priceUI;
    public int buyingPrice;
    public int sendingPrice;
    public bool inMarket = false;

    // Stats add by item
    public int expAdd;
}

