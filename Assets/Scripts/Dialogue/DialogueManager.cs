using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {
    
    public void StartSequence(int dialogueSequenceID)
    {
        // Look up ID in database
        List<Dialogue> sequence = FindObjectOfType<JSONDialogue>().GetDialogueSequence(dialogueSequenceID);

        // Pass value to DialogueDisplay
        ManagerScripts.instance.dialogueDisplay.StartDialogueSequence(sequence);
    }

    public void StartSequenceFromXML (TextAsset xmlDialogue)
    {
        ManagerScripts.instance.timeManager.ChangeGameState(TimeManager.GameTimeState.Talking);
        // Send XML through a parse and recieve a List<Dialogue> back
        List<Dialogue> sequence = DialogueSequence.Load(xmlDialogue.text).Dialogue;

        // Send the List<Dialogue> to DialogueDisplay
        ManagerScripts.instance.dialogueDisplay.StartDialogueSequence(sequence);
    }
}
