using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalk : Interactable {

    public DialogueTrigger dialogueTrigger;

    new void Update()
    {
        base.Update();
    }


    public override void Interact()
    {
        base.Interact();
        dialogueTrigger.TriggerDialogue();
        Debug.Log("Interacting with");
    }
}
