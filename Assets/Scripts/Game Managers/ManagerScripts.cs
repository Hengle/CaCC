using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerScripts : MonoBehaviour {

    #region Singleton
    public static ManagerScripts instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one DevOuput instance");
            return;
        }
        instance = this;
    }
#endregion

    public InteractionManager interactionManager;
    public DialogueManager dialogueManager;
    public DialogueDisplay dialogueDisplay;
    public TimeManager timeManager;
}
