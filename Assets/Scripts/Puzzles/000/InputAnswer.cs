using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputAnswer : MonoBehaviour {

    public InputField playerAnswer;

    private string answerFinal; 

    //call this from any other puzzle script and inject the correct answer

    public void SetAnswer (string answer) 
    {
        answerFinal = answer;
    }

	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Return))
        {
            CheckAnswer();
        }
    }
    
    void CheckAnswer ()
    {
        if (playerAnswer.text.Equals(answerFinal))
        {
            SceneManager.LoadScene("CorrectScreen");
        }
        else
        {
            SceneManager.LoadScene("IncorrectScreen");
        }
    }
}
    