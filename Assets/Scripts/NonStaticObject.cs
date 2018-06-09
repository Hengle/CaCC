using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonStaticObject : MonoBehaviour {

    public float id;

    // On component added
    private void Reset()
    {
        GenerateUniqueID();
    }

    private void GenerateUniqueID()
    {
        id = FindObjectOfType<GlobalVar>().GenerateID();
    }
}
