
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool startDialogue = false;

    void Update()
    {
        if(startDialogue == true) 
        {
            TriggerDialogue();
            startDialogue = false;
        }
    }

    void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
