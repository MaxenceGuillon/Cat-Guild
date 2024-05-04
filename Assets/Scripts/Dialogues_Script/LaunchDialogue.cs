using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDialogue : MonoBehaviour
{
    public DialogueTrigger dialogueTrigger;

    void Start()
    {
        if (DataPlayer.instance.AdventureCount < DataPlayer.instance.maxAdventure)
        {
            dialogueTrigger.startDialogue = true;
        }
        else
        {
            OpenPanels.instance.OpenDialogueComeBackLaterPanel();
        }
    }
}
