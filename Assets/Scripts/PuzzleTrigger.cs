using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleTrigger : MonoBehaviour {

    public string ID;
    public WorldStreamer.LoadState loadType;
    public List<string> newScenesToLoad;

    public void Trigger()
    {
        if (loadType == WorldStreamer.LoadState.Return)
        {
            WorldStreamer.instance.LoadPuzzle(ID);
        }
        else if (loadType == WorldStreamer.LoadState.NewScenes)
        {
            WorldStreamer.instance.LoadPuzzle(ID, newScenesToLoad);
        }
    }
}
