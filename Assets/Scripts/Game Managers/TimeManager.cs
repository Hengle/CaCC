using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    public enum GameTimeState { Moving, Talking, Pause}
    private GameTimeState gameState;
    public GameTimeState GameState
    {
        get { return gameState; }
        set { }
    }

    public GameObject pauseMenu;

    public void ChangeGameState(GameTimeState gameState)
    {
        this.gameState = gameState;

        if (this.gameState == GameTimeState.Pause)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (this.gameState == GameTimeState.Moving)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (this.gameState == GameTimeState.Talking)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (this.gameState == GameTimeState.Pause)
            {
                ChangeGameState(GameTimeState.Moving);
            }
            else if (this.gameState == GameTimeState.Moving)
            {
                ChangeGameState(GameTimeState.Pause);
            }
            else if (this.gameState == GameTimeState.Talking)
            {
                Debug.Log("Can't pause during dialogue");
            }
        }
    }
}
