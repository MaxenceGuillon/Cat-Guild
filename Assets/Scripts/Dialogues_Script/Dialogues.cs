using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public bool addCat = false; // Boolean to determinate if the NPC join the guild at the end of current dialogue

    public CatData npcCat;
    public string nameNPC;

    public float energyCost; // Energy cost to display the NPC's segond sentence

    [TextArea(3,10)]
    public string[] sentences;

    public Sprite visualOfCatSpeaker;
}
