﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilePanel : MonoBehaviour {

    public Text fileName;
    public Text date;

    public void Click()
    {
        FindObjectOfType<SaveManager>().Load(fileName.text);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
