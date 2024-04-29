using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{ 
    public Text nameText;
    public Text dialogueText;
    public Image visual;
    public Dialogue temporalyDialogue;

    public ModificationOfCollectionOfCats modificationOfCollectionOfCats;


    public Animator animator;

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

        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        temporalyDialogue = dialogue;
        nameText.text = dialogue.nameNPC;
        visual.sprite = dialogue.visualOfCatSpeaker;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue(temporalyDialogue);
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void EndDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", false);
        if(dialogue.addCat == true)
        {
            modificationOfCollectionOfCats.newCatAdd = temporalyDialogue.newCat;
            modificationOfCollectionOfCats.checker = true;
        }
    }
}
