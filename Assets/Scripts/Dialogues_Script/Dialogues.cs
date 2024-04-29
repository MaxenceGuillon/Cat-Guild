using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{

    public int idDialogue;
    public bool addCat = false;
    public CatID newCat;
    public string nameNPC;

    [TextArea(3,10)]
    public string[] sentences;

    public Sprite visualOfCatSpeaker;
}
