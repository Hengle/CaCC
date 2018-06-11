using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TEMPORARY : MonoBehaviour {

    //the purpose of this script is to get back to the puzzle screen from the Correct! and Incorrect! screens for dev purposes

    public void ChangeScene ()
    {
        SceneManager.LoadScene("Puzzle000");
    }
}    
