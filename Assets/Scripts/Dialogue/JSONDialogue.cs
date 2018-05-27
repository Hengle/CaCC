using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JSONDialogue : MonoBehaviour {

    private string path;
    private string rawJson; // Raw json data

    private List<List<Dialogue>> dialogueSequences;

    private void Start()
    {
        path = Application.streamingAssetsPath + "/DialogueDatabase.json";
    }

    private void DeserializeJSON()
    {
        rawJson = File.ReadAllText(path);

        dialogueSequences = JsonConvert.DeserializeObject<List<List<Dialogue>>>(rawJson);
    }

    public List<Dialogue> GetDialogueSequence(int id)
    {
        DeserializeJSON();
        List<Dialogue> sequence = dialogueSequences[id];
        Clear();

        return sequence;
    }

    private void Clear()
    {
        dialogueSequences.Clear();
    }


    private void CreateJSONText()
    {
        List<Dialogue> example = new List<Dialogue>();
        //example.Add(new Dialogue("John", "Hello there!"));
        //example.Add(new Dialogue("Diamond", "How's it going?"));

        List<Dialogue> example2 = new List<Dialogue>();
        //example2.Add(new Dialogue("Coon", "Welcome"));
        //example2.Add(new Dialogue("CXZ", "Very"));

        List<List<Dialogue>> sequences = new List<List<Dialogue>>();
        sequences.Add(example);
        sequences.Add(example2);


        var jsonString = JsonConvert.SerializeObject(sequences, Formatting.Indented);
        File.WriteAllText(path, jsonString);
        Debug.Log(jsonString);

        rawJson = File.ReadAllText(path);
        
        List<List<Dialogue>> newExample = JsonConvert.DeserializeObject<List<List<Dialogue>>>(rawJson);

        Debug.Log(newExample[0][0].CharacterName);
        Debug.Log(newExample[0][0].DialogueText);
        Debug.Log(newExample[1][0].CharacterName);
        Debug.Log(newExample[1][0].DialogueText);
    }
}
