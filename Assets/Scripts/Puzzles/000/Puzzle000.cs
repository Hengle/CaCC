using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle000 : MonoBehaviour {

    public InputField inputNumber; 
    public Text outputText; 
    public Text invalidInputDisplay;

    //I did the timer wrong, it'll be an easy fix tho

    private float invalidTextTimer = 0; 
    private string answer = "7422"; //for single input
    private string[] answers = new string[4] { "7422", "7142", "1782", "7593" }; //set correct answer to first thing in array
    private int answerIndex = 3; //determines if the correct answer is A, B, C or D

    private InputAnswer inputAnswerScript;
    private MultiChoice multiChoiceScript;
    
    void Start ()
    {
        inputAnswerScript = FindObjectOfType<InputAnswer>();
        multiChoiceScript = FindObjectOfType<MultiChoice>();

        inputAnswerScript.SetAnswer(answer); //feed into input field answer script

        multiChoiceScript.SetAnswers(answers, answerIndex); //feed into multiple choice answer script
    }

    public void CheckIfValid ()
    {
        int number = int.Parse(inputNumber.text);

        if (inputNumber.text.Length == 4)
        {
            if (number >= 1000 && number <= 7999)
            {
                ConvertFromInput();
            }
            else
            {
                InvalidInput(); 
            }
        }
        else
        {
            InvalidInput();
        }
      
    }

    public void ConvertFromInput ()  
    {
        int[] inputArray = new int[4];

        for (int i = 0; i < 4; i++)
        {
            int z = 0;
            if (Int32.TryParse(inputNumber.text[i].ToString(), out z))
            {
                inputArray[i] = z;

            }
            else
            {
                InvalidInput();
                return;
            }
        }

        ConvertToOutput(inputArray);
    }

    private void ConvertToOutput (int[] inputArray)
    {
        int[] outputArray = new int[4];

        outputArray[0] = ModifyFirst(inputArray[0]);
        outputArray[1] = ModifySecond(inputArray[1]);
        outputArray[2] = ModifyThird(inputArray[2]);    
        outputArray[3] = ModifyFourth(inputArray[3]);

        int finalOutput = 0;
        for (int i = 0; i < outputArray.Length; i++)
        {
            finalOutput += outputArray[i] * Convert.ToInt32(Math.Pow(10, outputArray.Length-i-1));
        }

        outputText.text = finalOutput.ToString();

    }

    int ModifyFirst(int a)
    {
        a = (a * 2) - 1;    

        if (a >= 10)
        {
            return a % 10;
        } 
        else
        {
            return a;
        }
            
    }

    int ModifySecond(int b)
    {
        b = b * 3;

        if (b >= 10)
        {
            return b % 10;
        }
        else
        {
            return b;
        }
        
    }

    int ModifyThird(int c)
    {
        return c;

    }

    int ModifyFourth(int d)
    {
        d = d + 1;
        if (d >= 10)
        {
            return d % 10;
        }
        else
        {
            return d;
        }
       
    }   

    private void InvalidInput ()
    {
        invalidInputDisplay.text = "Not a valid number!";

        if (invalidTextTimer >= 2f)
        {
            invalidTextTimer = 0f;
            invalidInputDisplay.text = null; 
            
            //how do I get rid of the text after 2 seconds lol
        }

        invalidTextTimer += Time.deltaTime; 
    }
}
