using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : Interactable {

    public PuzzleTrigger puzzleTrigger;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	new void Update () {
        base.Update();
        
    }


    public override void Interact()
    {
        base.Interact();
        puzzleTrigger.Trigger();
    }
}
