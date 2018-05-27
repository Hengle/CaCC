using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLParser {

}

public class Item
{
    [XmlAttribute("name")]
    public string name;

    [XmlElement("Damage")]
    public float damage;

    [XmlElement("Durability")]
    public float durability;
}

[XmlRoot("ItemCollection")]
public class ItemContainer
{
    [XmlArray("Items")]
    [XmlArrayItem("Item")]
    public List<Item> items = new List<Item>();

    public static ItemContainer Load(TextAsset xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ItemContainer));

        StringReader reader = new StringReader(xml.text);

        ItemContainer items = serializer.Deserialize(reader) as ItemContainer;

        reader.Close();

        return items;
    }
}

[XmlRoot("DialogueSequence")]
public class DialogueSequence
{
    [XmlElement("Dialogue")]
    public List<Dialogue> Dialogue { get; set; }

    public static DialogueSequence Load(string xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(DialogueSequence));
        using (TextReader reader = new StringReader(xml))
        {
            DialogueSequence result = (DialogueSequence)serializer.Deserialize(reader);
            return result;
        }
    }
}

public class DialogueX
{
    [XmlElement("CharacterName")]
    public string CharacterName { get; set; }

    [XmlElement("DialogueText")]
    public string DialogueText { get; set; }
}



