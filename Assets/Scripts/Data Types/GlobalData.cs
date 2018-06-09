using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class GlobalData
{
    // Various global bools for game progress
    // Int (or multiple) for the current game state (NPC's may derive their logic or position based on this)
    // Take from GlobalVar script

    public int gameState;
    
    public GlobalData(GlobalVar globalVar)
    {
        gameState = globalVar.gameState;
    }
}
