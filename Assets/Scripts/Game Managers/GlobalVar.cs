using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour {

    #region Singleton
    public static GlobalVar instance;
    private void Awake()
    {
        if (instance != null)
        {
            GetComponent<WorldStreamer>().enabled = false;
            // Code before complete destruction of object
            instance.runtime = runtime;
            Destroy(this.gameObject);
            Debug.Log("Destroyed");
        }
        else
        {
            if (instance == null)
                instance = this;
            DontDestroyOnLoad(this.gameObject);
            GameState = State.Roaming;
        }
    }
    #endregion

    public enum State { Roaming, Dialogue, Puzzle };
    public State GameState { get; set; }

    // Just a test, add global vars when needed
    // Mostly for NPC logic
    public RuntimeVars runtime;


    // Should actually be in seperate class and doesnt belong in GlobalVar
    // But for simplicities sake its here
    public MetaData metaData;

    public int gameState;

    // Used for generating unique ID's
    private int numberOfNonStaticObjects;

    public void Load(GlobalData globalData)
    {
        gameState = globalData.gameState;
    }

    public int GenerateID()
    {
        int z = numberOfNonStaticObjects;
        numberOfNonStaticObjects++;
        return z;
    }
}

// Variables that need to be accessed at runtime, which are also updated when the scene is reload (like after puzzle completion)
[System.Serializable]
public class RuntimeVars
{
    public GameObject interactionOverlay;
    public GameObject player;
    public GameObject pauseOverlay;
}
