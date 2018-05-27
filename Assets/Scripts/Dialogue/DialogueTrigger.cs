using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public TextAsset xml;

    public void TriggerDialogue()
    {
        Debug.Log("Trigger Dialogue");
        ManagerScripts.instance.dialogueManager.StartSequenceFromXML(xml);
    }
}
