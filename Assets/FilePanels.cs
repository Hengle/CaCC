using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class FilePanels : MonoBehaviour {

    public GameObject filePanel;

    string path;
    string[] files;

	// Use this for initialization
	void Start () {
        if (Application.isEditor)
            path = Application.dataPath + @"\GameData\Saves";
        else
            path = Application.dataPath + @"\Saves";

        files = Directory.GetFiles(path, "*.svv");

        SpawnPanels();
    }
	
    void SpawnPanels()
    {
        for (int i = 0; i < files.Length; i++)
        {
            GameObject c= Instantiate(filePanel, transform);
            c.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 150 * (i + 1) * -1, 0);
            c.GetComponent<FilePanel>().fileName.text = Path.GetFileName(files[i]);
            DateTime dateTime = File.GetLastWriteTime(files[i]);
            c.GetComponent<FilePanel>().date.text = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
        }
    }
}
