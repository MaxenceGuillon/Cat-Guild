using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

// Loading_Scene ( in GameObject : GameManager / DialogueManager ) 

public class DialogueManager : MonoBehaviour
{
    // Main dialogue panel
    public Text nameText;
    public Text dialogueText;
    public Text energyCostText;
    public Image visual;

    // Continue button in dialogue panel
    public Text endDialogueButtonText;
    public GameObject endDialogueGameObject;
    public GameObject continueDialogueTextGameObject;
    public GameObject lockDoubleCatAdd; // Double add cat lock

    // Others panels
    public GameObject panelNewCat;
    public GameObject panelNoEnergy;
    
    // Dialogue tools 
    public Dialogue temporalyDialogue;
    public int sentencesNumberTempo;
    public int sentencesRead;

    // Energy tools
    public float energyCostTempo;
    public float rateEnergy = 1.2f;

    // Panels's Animation
    public Animator openPanelDialogueAnim;
    public Animator openPanelUnsufficientEnergyAnim;

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;

    private Queue<string> sentences;

    public static DialogueManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DialogueManager dans la scène");
            return;
        }

        instance = this;

        sentences = new Queue<string>(); // Init of queue to dialogue
    }

    // Print informations and visual of current NPC dialogue
    public void StartDialogue(Dialogue dialogue)
    {
        openPanelDialogueAnim.SetBool("isOpen", true);
        temporalyDialogue = dialogue;

        continueDialogueTextGameObject.SetActive(true);
        endDialogueGameObject.SetActive(false);
        nameText.text = dialogue.nameNPC;
        visual.sprite = dialogue.visualOfCatSpeaker;
        energyCostText.text = dialogue.energyCost.ToString();

        // Sentence initialization
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        // Case of dialogue not finish
        if (GameManager.instance.dialogueNotFinish == true)
        {
            sentencesRead = sentences.Count - sentencesNumberTempo;

            for (int i = 0; i < sentencesRead; i++)
            {
                sentences.Dequeue();
            }
            GameManager.instance.dialogueNotFinish = false;
        }
        else
        {
            energyCostTempo = dialogue.energyCost;
            sentencesNumberTempo = sentences.Count;
        }

        DisplayFirstSentence();
    }

    // Write first sentence
    public void DisplayFirstSentence()
    {
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
    }

    // Write next sentence
    public void DisplayNextSentence()
    {
        // Case : you are at the last sentence of dialogue
        if (sentences.Count == 0)
        {
            EndDialogue(temporalyDialogue);
            lockDoubleCatAdd.SetActive(true);
            return;
        }
        else
        {
            // Case : you don't have any energy to continue 
            if (DataPlayer.instance.lockProgress == true)
            {
                StopAllCoroutines();
                panelNoEnergy.SetActive(true);
                StartCoroutine(WaitForAnimationUnsufficientEnergy(2.0f));
                return;
            }
            else
            {
                // Normal case : Write next sentence 
                sentencesNumberTempo--;
                string sentence = sentences.Dequeue();
                StopAllCoroutines();
                StartCoroutine(TypeSentence(sentence));
                sentencesRead++;
            }
        }
    }

    public void EndDialogue(Dialogue dialogue)
    {
        openPanelDialogueAnim.SetBool("isOpen", false);
        energyCostTempo = 0;
        
        // Unlock next zone when player finish current zone
        if (GameManager.instance.iDZoneChoose+1 < GameManager.instance.numberOfZone) GameManager.instance.zonesUnlockList[GameManager.instance.iDZoneChoose + 1] = true;

        //Case : Player end a zone and NPC join the guild
        if (dialogue.addCat == true)
        {
            panelNewCat.SetActive(true);
            modificationOfCollectionOfCats.newCatAdd.cat = temporalyDialogue.npcCat;
            modificationOfCollectionOfCats.checker = true;
        }

        DataPlayer.instance.NextAdventure();

        //Reinitilization of dialogue tools
        sentencesRead = 0;
        sentencesNumberTempo = 0;
    }

    // Increment of cost value to access to the next sentence
    public void EnergyCostModification()
    {
        if (DataPlayer.instance.lockProgress == true) return;
        else energyCostTempo = math.trunc(energyCostTempo * rateEnergy);
    }

    public void EnergyConsume()
    {
        DataPlayer.instance.EnergyModification(-energyCostTempo);
    }

    // Method to animate panels UI
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator WaitForAnimationUnsufficientEnergy(float f)
    {
        openPanelUnsufficientEnergyAnim.SetBool("PanelUnsufficientEnergyIsOpen", true);
        yield return new WaitForSeconds(f);
        openPanelUnsufficientEnergyAnim.SetBool("PanelUnsufficientEnergyIsOpen", false);
    }

    private void Update()
    {
        if (energyCostTempo > 0) energyCostText.text = energyCostTempo.ToString(); // Print cost of continue button

        // Modification of continue button text at the end of dialogue
        if ((sentencesNumberTempo == 1))
        {
            if (temporalyDialogue.addCat == true) // Case : NPC join the guild
            {
                continueDialogueTextGameObject.SetActive(false);
                endDialogueGameObject.SetActive(true);
                endDialogueButtonText.text = "Add new cat >>";
            }
            if (temporalyDialogue.addCat == false) // Case : NPC don't join the guild
            {
                continueDialogueTextGameObject.SetActive(false);
                endDialogueGameObject.SetActive(true);
                endDialogueButtonText.text = "Come back to guild";
                GameManager.instance.toMainPage = true;
            }
        }
    }

}
