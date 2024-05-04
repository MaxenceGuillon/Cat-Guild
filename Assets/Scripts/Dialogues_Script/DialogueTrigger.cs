
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public bool startDialogue = false;


    public Dialogue currentDialogue;
    public Animator animator;

    public List<DialogueID> Adventures = new List<DialogueID>();

    public static DialogueTrigger instance;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Adventures dans la scène");
            return;
        }
        instance = this;
    }

    void Update()
    {
        if(DataPlayer.instance.AdventureCount < DataPlayer.instance.maxAdventure)
        {
            currentDialogue = Adventures[DataPlayer.instance.AdventureCount].dialogue;
        }

        if (startDialogue == true) 
        {
            TriggerDialogue(currentDialogue);

            startDialogue = false;
        }
    }

    void TriggerDialogue(Dialogue dialogueType)
    {

        DialogueManager.instance.StartDialogue(dialogueType);
    }
}
