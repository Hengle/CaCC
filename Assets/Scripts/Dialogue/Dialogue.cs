using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;

public class Dialogue {

    [XmlElement("CharacterName")]
    public string CharacterName;

    [XmlElement("DialogueText")]
    public string DialogueText;
}






