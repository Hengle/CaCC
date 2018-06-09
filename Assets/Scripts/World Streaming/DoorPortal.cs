using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPortal : MonoBehaviour {

    public DoorType type;
    public string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Triggered");
            WorldStreamer.instance.StreamScene(type, sceneName);
        }
    }
}
