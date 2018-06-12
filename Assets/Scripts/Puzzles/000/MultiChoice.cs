using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MultiChoice : MonoBehaviour {
    
    //this script lags the shit out of unity for some reason; pls fix
    //every other script works fine tho, just this one seems to fuck stuff up

    private Button[] buttons = new Button[4];
    private Button correctButton;

    
    //call this from any other puzzle script and inject an array of answers to be randomly assigned to a button

    void Start ()
    {
        buttons = GetComponentsInChildren<Button>();
    }

    public void SetAnswers (string[] answers, int index)
    {
        correctButton = buttons[index];

        int i;
        for (i = 0; i < 4; i++)
        {
            //it's saying this is wrong, however I checked array sizes and everything and nothing is too small so IDK

            buttons[i].GetComponentInChildren<Text>().text = answers[i]; 
        }
    }

    void Update ()
    {
        if(correctButton != null)
        {
            ButtonPressed();
        }
    }

    void ButtonPressed ()
    {
        correctButton.onClick.AddListener(CorrectAnswer);
    
        //sorry about the spaghetti code below, my deadline was in 10 mins I couldn't figure out why the fuck my other method worked for every button except 1

        if (buttons[0] != correctButton)
        {
            buttons[0].onClick.AddListener(IncorrectAnswer);
        }
        else if (buttons[1] != correctButton)
        {
            buttons[1].onClick.AddListener(IncorrectAnswer);
        }
        else if (buttons[2] != correctButton)
        {
            buttons[2].onClick.AddListener(IncorrectAnswer);
        }
        else if (buttons[3] != correctButton)
        {
            buttons[3].onClick.AddListener(IncorrectAnswer);
        }

    }

    void CorrectAnswer ()
    {
        SceneManager.LoadScene("CorrectScreen");
    }

    void IncorrectAnswer ()
    {
        SceneManager.LoadScene("IncorrectScreen");
    }
}
 