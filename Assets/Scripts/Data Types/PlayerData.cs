using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[Serializable]
public class PlayerData {

    public float[] position;
    public float[] rotation;
    public List<string> activeScenes;

    // Add further save data (related to the player) such as the outfit
    // Data like amount of puzzle points will be in GlobalData rather than player

    public PlayerData (GameObject player, List<string> activeScenes)
    {
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        rotation = new float[3];
        rotation[0] = player.transform.rotation.eulerAngles.x;
        rotation[1] = player.transform.rotation.eulerAngles.y;
        rotation[2] = player.transform.rotation.eulerAngles.z;

        this.activeScenes = new List<string>();
        for (int i = 0; i < activeScenes.Count; i++)
        {
            this.activeScenes.Add(activeScenes[i]);
        }
    }
}
