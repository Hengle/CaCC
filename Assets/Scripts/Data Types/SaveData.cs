using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveData {

    // Meta Data
    public MetaData metaData;

    // List of PuzzleData
    public List<PuzzleData> puzzleData;

    // List of NonStaticData
    // Does not need to be implemented for now

    // GlobalData
    public GlobalData globalData;
    
    // PlayerData
    public PlayerData playerData;	

    public SaveData(PlayerData player, GlobalData global, MetaData meta, List<PuzzleData> puzzle)
    {
        globalData = global;
        playerData = player;
        metaData = meta;
        puzzleData = puzzle;
    }
}
