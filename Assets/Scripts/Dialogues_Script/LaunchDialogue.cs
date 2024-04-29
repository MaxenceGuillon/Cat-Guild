using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDialogue : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;
    void Start()
    {
        dialogueTrigger.startDialogue = true;
    }
}
