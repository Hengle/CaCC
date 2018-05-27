using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevOutput : MonoBehaviour {

    #region Singleton
    public static DevOutput instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one DevOuput instance");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject[] debugWindows;
    public Text outputText;

    public void Output(string text)
    {
        outputText.text += text + "\r\n";
    }

    public void OutputMultipleLines(string text)
    {
        outputText.text += text;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            foreach (GameObject obj in debugWindows)
            {
                if (obj.activeInHierarchy == true)
                    obj.SetActive(false);
                else
                    obj.SetActive(true);
            }
        }
    }


}
