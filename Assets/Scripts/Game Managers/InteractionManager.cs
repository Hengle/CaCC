using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {

    #region Singleton
    public static InteractionManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    private List<Interactable> allInteractables;
    private List<Interactable> inRangeObjects = new List<Interactable>();

    private Interactable currentSelected;

    private void Start()
    {
        allInteractables = new List<Interactable>();
    }

    private void OnEnable()
    {

    }

    public void AddToInteractables(Interactable interactable)
    {
        allInteractables.Add(interactable);
    }

    public void RemoveFromInteractables(Interactable interactable)
    {
        allInteractables.Remove(interactable);
    }

    private void Update()
    {
        if (GlobalVar.instance.GameState != GlobalVar.State.Roaming)
        {
            return;
        }

        inRangeObjects.Clear();

        foreach (Interactable i in allInteractables)
        {
            if (i._inRange)
            {
                inRangeObjects.Add(i);
            }
        }

        if (inRangeObjects.Count == 0)
        {
            GlobalVar.instance.runtime.interactionOverlay.SetActive(false);
            currentSelected = null;
        } 
        else if (inRangeObjects.Count == 1)
        {
            GlobalVar.instance.runtime.interactionOverlay.SetActive(true);
            GlobalVar.instance.runtime.interactionOverlay.GetComponentInChildren<Text>().text = inRangeObjects[0].overlayText;
            currentSelected = inRangeObjects[0];
        } 
        else
        {
            int z = 0;
            for (int i = 0; i < inRangeObjects.Count; i++)
            {
                if (inRangeObjects[i].distance < inRangeObjects[z].distance)
                {
                    z = i;
                }
            }
            GlobalVar.instance.runtime.interactionOverlay.SetActive(true);
            GlobalVar.instance.runtime.interactionOverlay.GetComponentInChildren<Text>().text = inRangeObjects[z].overlayText;
            currentSelected = inRangeObjects[z];

        }

        if (currentSelected != null && Input.GetKeyDown(KeyCode.E))
        {
            currentSelected.Interact();
        }
    }
}
