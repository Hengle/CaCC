using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public enum GameState { Paused, Unpaused };
    public static GameState gameState = GameState.Unpaused;

    public GameObject pauseMenu;

	// Use this for initialization
	void Start () {
        UnpauseGame();
	}
	
	// Update is called once per frame
	void Update () {

	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
	}

    private void TogglePause()
    {
        if (gameState == GameState.Unpaused)
        {
            PauseGame();
        }
        else if (gameState == GameState.Paused)
        {
            UnpauseGame();
        }
    }

    private void PauseGame()
    {
        gameState = GameState.Paused;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }

    private void UnpauseGame()
    {
        gameState = GameState.Unpaused;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
