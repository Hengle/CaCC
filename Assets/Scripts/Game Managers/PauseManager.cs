using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

    #region Singleton
    public static PauseManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public enum State { Menu, InGame, Puzzle };

    public State SceneState { get; set; }
    public bool Paused { get; set; }

    // Get pause menu from global var
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneState == State.InGame)
        {
            if (!Paused)
            {
                // Pause game
                PauseGame();
            }
            else
            {
                // Unpause game
                UnpauseGame();
            }
        }
    }

    void PauseGame()
    {
        Paused = true;
        Time.timeScale = 0;
        GlobalVar.instance.runtime.pauseOverlay.SetActive(true);
    }

    void UnpauseGame()
    {
        Paused = false;
        Time.timeScale = 1;
        GlobalVar.instance.runtime.pauseOverlay.SetActive(false);
    }
}
