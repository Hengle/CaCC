using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour {

    // Consider changing this class to static
    void Start()
    {
        
    }


    private void Update()
    {
        if (GlobalVar.instance.GameState != GlobalVar.State.Roaming)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            //Load();
        }
    }

    public void Save()
    {
        PlayerData player = new PlayerData(GlobalVar.instance.runtime.player, WorldStreamer.instance.loadedScenes);
        GlobalData global = new GlobalData(GlobalVar.instance);
        MetaData meta = GlobalVar.instance.metaData;
        List<PuzzleData> puzzle = PuzzleManager.instance.puzzles;

        SaveData saveData = new SaveData(player, global, meta, puzzle);
        SaveFormatter.Save(saveData);
    }

    public void Load(string name)
    {
        SaveData saveData = SaveFormatter.Load(name);

        WorldStreamer.instance.LoadFromFile(saveData.playerData);

        // Global Loading
        GlobalVar.instance.Load(saveData.globalData);

        // Puzzle Loading
        PuzzleManager.instance.Load(saveData.puzzleData);

        // Player loading
        StartCoroutine(GetPlayerLoader(saveData.playerData));
    }

    IEnumerator GetPlayerLoader(PlayerData playerData)
    {
        if (GlobalVar.instance.runtime.player != null)
        {
            GlobalVar.instance.runtime.player.GetComponent<PlayerLoader>().Load(playerData);
        }
        else
        {
            yield return null;
        }
    }

    // Not used
    public void SavePlayer()
    {
        PlayerData playerData = new PlayerData(GlobalVar.instance.runtime.player, WorldStreamer.instance.loadedScenes);
        SaveFormatter.SavePlayer(playerData);
    }

    // Not used
    public void LoadPlayer()
    {
        PlayerData playerData = SaveFormatter.LoadPlayer();
        WorldStreamer.instance.Load(playerData);
        GlobalVar.instance.runtime.player.GetComponent<PlayerLoader>().Load(playerData);
    }
}

public static class SaveFormatter
{
    public static void Save(SaveData saveData)
    {
        BinaryFormatter bf = new BinaryFormatter();

        string path;
        if (Application.isEditor)
            path = Application.dataPath + @"\GameData\Saves\SAVE1.svv";
        else
            path = Application.dataPath + @"\Saves\SAVE1.svv";

        Directory.CreateDirectory(Path.GetDirectoryName(path));
        FileStream stream = new FileStream(path, FileMode.Create);

        bf.Serialize(stream, saveData);
        Debug.Log(path);
        stream.Close();
    }

    public static SaveData Load(string name)
    {
        // Replace with save load menu where you choose from a list of saves

        string path;
        if (Application.isEditor)
            path = Application.dataPath + @"\GameData\Saves\" + name;
        else
            path = Application.dataPath + @"\Saves\" + name;

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveData saveData = bf.Deserialize(stream) as SaveData;

            stream.Close();
            return saveData;
        }
        else
        {
            //Debug.Log("File does not exist");
            throw new UnityException("File does not exist | " + name);
        }
    }

    // Not used
    public static void SavePlayer(PlayerData playerData)
    {
        BinaryFormatter bf = new BinaryFormatter();

        string path;
        if (Application.isEditor)
            path = Application.dataPath + @"\GameData\Saves\player.svv";
        else
            path = Application.dataPath + @"\Saves\player.svv";

        Directory.CreateDirectory(Path.GetDirectoryName(path));
        FileStream stream = new FileStream(path, FileMode.Create);

        bf.Serialize(stream, playerData);
        Debug.Log(path);
        stream.Close();
    }

    // Not used
    public static PlayerData LoadPlayer()
    {
        // Replace with save load menu where you choose from a list of saves

        string path;
        if (Application.isEditor)
            path = Application.dataPath + @"\GameData\Saves\player.svv";
        else
            path = Application.dataPath + @"\Saves\player.svv";

        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData playerData = bf.Deserialize(stream) as PlayerData;

            stream.Close();
            return playerData;
        }
        else
        {
            //Debug.Log("File does not exist");
            throw new UnityException("File does not exist");
        }
    }
}
