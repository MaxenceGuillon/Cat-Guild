using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[CreateAssetMenu(fileName = "Zone", menuName = "Zones/New Zone")]

public class DataZone : ScriptableObject
{
    //UI variables of zone
    public string zoneName;
    public Sprite zoneVisual;

    // variable to control the print in Map_scene
    public bool unlockBool;

    // Variable to control animation "open panel is first time in this zone"
    public bool isFirstTime = true;

}