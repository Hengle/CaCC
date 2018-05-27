using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionManager : MonoBehaviour {

    public GameObject interactionOverlay;

    private Interactable[] allInteractables;
    private List<Interactable> inRangeObjects = new List<Interactable>();

    private Interactable currentSelected;

    private void Start()
    {
        allInteractables = GameObject.FindObjectsOfType<Interactable>();
    }

    private void Update()
    {
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
            interactionOverlay.SetActive(false);
            currentSelected = null;
        } 
        else if (inRangeObjects.Count == 1)
        {
            interactionOverlay.SetActive(true);
            interactionOverlay.GetComponentInChildren<Text>().text = inRangeObjects[0].overlayText;
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
            interactionOverlay.SetActive(true);
            interactionOverlay.GetComponentInChildren<Text>().text = inRangeObjects[z].overlayText;
            currentSelected = inRangeObjects[z];

        }

        if (currentSelected != null && Input.GetKeyDown(KeyCode.E))
        {
            currentSelected.Interact();
        }
    }
}
