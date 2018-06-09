using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour {

    #region Singleton
    public static PuzzleManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public List<PuzzleData> puzzles = new List<PuzzleData>();

    public void Load(List<PuzzleData> puzzleData)
    {
        puzzles = puzzleData;
    }

    public void PuzzleCompleted(string ID, int pointsReceived)
    {
        // TODO Find puzzle with the ID and set to complete and pointsReceived

        WorldStreamer.instance.PuzzleComplete(ID);
    }
}
