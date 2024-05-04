using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public bool addCat = false;
    public CatData newCat;
    public string nameNPC;

    [TextArea(3,10)]
    public string[] sentences;

    public Sprite visualOfCatSpeaker;
}

[System.Serializable]
public class DialogueID
{
    public Dialogue dialogue;
    public int id;
}
