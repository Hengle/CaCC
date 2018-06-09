using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour {

    public void Load(PlayerData playerData)
    {
        transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
        transform.rotation = Quaternion.Euler(new Vector3(playerData.rotation[0], playerData.rotation[1], playerData.rotation[2]));
    }
}
