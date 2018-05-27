using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatMenuDisplay : MonoBehaviour {

    private Text text;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Game State: " + PauseMenu.gameState.ToString() + "\r\n";
        text.text += "Player Position: " + PlayerManager.instance.player.transform.position.ToString() + "\r\n";
        text.text += "Player Grounded: " + PlayerManager.instance.player.GetComponent<CharacterController>().isGrounded + "\r\n";
        text.text += "Player Velocity: " + PlayerManager.instance.player.GetComponent<CharacterController>().velocity.magnitude + "\r\n";
    }
}
