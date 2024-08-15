
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Adventure_Scene ( in GameObject : DialogueAdventure ) 

public class DialogueTrigger : MonoBehaviour
{
    public bool startDialogue = false; // Boolean to confirm to print dialogue UI
    public Dialogue currentDialogue;

    public List<Dialogue> adventures = new List<Dialogue>(); // List to write many dialogues for the narrative designer 

    // Check if player can access to the next dialogue
    void Start()
    {
        if (DataPlayer.instance.AdventureCount < DataPlayer.instance.maxAdventure) startDialogue = true;
        else OpenPanels.instance.OpenDialogueComeBackLaterPanel();
    }

    void TriggerDialogue(Dialogue dialogueType)
    {
        DialogueManager.instance.StartDialogue(dialogueType);
    }

    //Set and launch current dialogue print in panel UI
    void Update()
    {
        if(DataPlayer.instance.AdventureCount < DataPlayer.instance.maxAdventure) currentDialogue = adventures[DataPlayer.instance.AdventureCount];
        if (startDialogue == true) 
        {
            TriggerDialogue(currentDialogue);
            startDialogue = false;
        }
    }
}
