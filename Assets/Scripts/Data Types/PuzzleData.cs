using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PuzzleData {

    public string ID
    {
        get
        {
            return ID;
        }
        set
        {
            if (value.Length != 3)
            {
                throw new System.Exception("ID value must be 3 digits");
            }
            else
            {
                ID = value;
            }
        }
    }
    public bool Unlocked { get; set; } // Unused for now
    public bool Completed { get; set; } 
    public int Points { get; set; }
    public int PointsRecieved { get; set; }

    public PuzzleData(string ID, int points)
    {
        this.ID = ID;
        Points = points;
    }

    public void Complete(int pointsReceived)
    {
        Completed = true;
        PointsRecieved = pointsReceived;
    }
}
