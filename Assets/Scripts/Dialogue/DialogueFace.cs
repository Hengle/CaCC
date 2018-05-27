using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueFace : MonoBehaviour {

    public Sprite barry;
    public Sprite diamond;
    
    public void UpdateFace(string name)
    {
        // Replace later with database lookup of some sort
        Image image = GetComponent<Image>();

        switch (name.ToString())
        {
            case "John":
                image.sprite = barry;
                break;
            case "Amelia":
                image.sprite = diamond;
                break;
            default:
                Debug.Log("NO SPRITE FOR THIS CHARACTER");
                break;
        }
    }
}
