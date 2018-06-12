using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptManager : MonoBehaviour {

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnNewSceneLoaded;
    }

    private void Disable()
    {
        SceneManager.sceneLoaded -= OnNewSceneLoaded;
    }

    void OnNewSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Start Menu")
        {
            GetComponent<InteractionManager>().enabled = false;
            GetComponent<PauseManager>().SceneState = PauseManager.State.Menu;
        }
        else if (scene.name == "BaseScene")
        {
            GetComponent<InteractionManager>().enabled = true;
            GetComponent<PauseManager>().SceneState = PauseManager.State.InGame;
        }
        else if (scene.name.Contains("Puzzle_"))
        {
            GetComponent<PauseManager>().SceneState = PauseManager.State.Puzzle;
            GetComponent<InteractionManager>().enabled = false;
        }
    }
}
