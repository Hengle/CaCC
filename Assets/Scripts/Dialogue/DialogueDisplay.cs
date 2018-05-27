using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDisplay : MonoBehaviour {

    public Text characterNameText;
    public Text dialogueText;
    public DialogueFace characterFaceSprite;
    public GameObject holder;

    public Queue<Dialogue> dialogueQueue = new Queue<Dialogue>();

    // Test variables
    private List<Dialogue> testDialogue = new List<Dialogue>();


    private void Start()
    {
        holder.SetActive(false);
        //testDialogue.Add(new Dialogue("John", "Hello there!"));
    }

    public void StartDialogueSequence (List<Dialogue> dialogueSequence)
    {
        holder.SetActive(true);
        // First convert dialogue sequence list to queue
        dialogueQueue.Clear();

        foreach(Dialogue d in dialogueSequence)
        {
            dialogueQueue.Enqueue(d);
        }

        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue dialogue = dialogueQueue.Dequeue();
        
        characterNameText.text = dialogue.CharacterName;
        dialogueText.text = dialogue.DialogueText;

        //TODO Change characterFaceSprite to the correct image by looking up the name in some sort of database
        characterFaceSprite.UpdateFace(dialogue.CharacterName);
    }

    private void EndDialogue()
    {
        holder.SetActive(false);
        ManagerScripts.instance.timeManager.ChangeGameState(TimeManager.GameTimeState.Moving);
        Debug.Log("Conversation has ended");
    }
}
