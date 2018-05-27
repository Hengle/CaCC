using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatMenu : MonoBehaviour {

    public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.F3))
        {
            if (pauseMenu.activeInHierarchy == true)
            {
                pauseMenu.SetActive(false);
            }
            else
            {
                pauseMenu.SetActive(true);
            }
        }
	}
}
