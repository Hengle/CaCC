using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle000Temp : MonoBehaviour {

    public void CompletePuzzle()
    {
        PuzzleManager.instance.PuzzleCompleted("000", 0);
    }
}
