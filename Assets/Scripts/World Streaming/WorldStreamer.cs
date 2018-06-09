using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldStreamer : MonoBehaviour {

    #region Singleton
    public static WorldStreamer instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    #endregion

    public List<string> loadedScenes = new List<string>();


    // Puzzle Loading Variables 
    public enum LoadState { Return, NewScenes };
    public LoadState? loadState = null;
    public List<string> toLoad;
    public PlayerData playerData;

    void Start ()
    {
        // Replace with a save file initial scene loading system
    }

    public void Load(PlayerData playerData)
    {
        foreach (string s in playerData.activeScenes)
        {
            StartCoroutine(LoadAsyncAdditive(s));
        }
    }

    public void LoadFromFile(PlayerData playerData)
    {
        SceneManager.LoadSceneAsync("BaseScene", LoadSceneMode.Single);
        foreach (string s in playerData.activeScenes)
        {
            StartCoroutine(LoadAsyncAdditive(s));
        }
    }

    public void StreamScene(DoorType type, string sceneName)
    {
        bool sceneLoaded = false;

        for (int i = 0; i < loadedScenes.Count; i++)
        {
            if (loadedScenes[i] == sceneName)
            {
                sceneLoaded = true;
                break;
            }
        }

        if (type == DoorType.Load && !sceneLoaded)
        {
            StartCoroutine(LoadAsyncAdditive(sceneName));
        } 
        else if (type == DoorType.Unload && sceneLoaded)
        {
            StartCoroutine(UnloadAysnc(sceneName));
        }
    }

    IEnumerator UnloadAysnc(string sceneName)
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
        loadedScenes.Remove(sceneName);
    }

    IEnumerator LoadAsyncAdditive(string sceneName)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        loadedScenes.Add(SceneManager.GetSceneByName(sceneName).name);
    }

    // Same as LoadAsyncAdditive except reloads scenes in without adding to loadedScenes
    IEnumerator PuzzleSceneReload(List<string> loadedScenes, string ID)
    {
        SceneManager.LoadSceneAsync("BaseScene", LoadSceneMode.Single);

        for (int i = 0; i < loadedScenes.Count; i++)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(loadedScenes[i], LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }

        GlobalVar.instance.runtime.player.GetComponent<PlayerLoader>().Load(playerData);
        GlobalVar.instance.GameState = GlobalVar.State.Roaming;
        playerData = null;
        loadState = null;
    }

    //Puzzle Loading

    /// <summary>
    /// After puzzle completion returns back to original scene/s
    /// </summary>
    /// <param name="ID"></param>
    /// <param name=""></param>
    public void LoadPuzzle(string ID)
    {
        GlobalVar.instance.GameState = GlobalVar.State.Puzzle;
        loadState = LoadState.Return;
        playerData = new PlayerData(GlobalVar.instance.runtime.player, loadedScenes);
        SceneManager.LoadScene("Puzzle_" + ID.ToString(), LoadSceneMode.Single);
    }

    /// <summary>
    /// After puzzle completion loads a new set of scenes
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="newSceneNames"></param>
    public void LoadPuzzle(string ID, List<string> newSceneNames)
    {
        GlobalVar.instance.GameState = GlobalVar.State.Puzzle;
        loadState = LoadState.NewScenes;
        toLoad = newSceneNames;
        playerData = new PlayerData(GlobalVar.instance.runtime.player, loadedScenes);
        Debug.Log(playerData.activeScenes[0]);
        SceneManager.LoadScene("Puzzle_" + ID, LoadSceneMode.Single);
    }

    public void PuzzleComplete(string ID)
    {
        if (loadState == LoadState.Return)
        {
            StartCoroutine(PuzzleSceneReload(playerData.activeScenes, ID));
        }
        else if (loadState == LoadState.NewScenes)
        {
            loadedScenes.Clear();
            foreach (String s in toLoad)
            {
                StartCoroutine(LoadAsyncAdditive(s));
            }
            toLoad.Clear(); // Might clear before all toLOads are loaded check later

            GlobalVar.instance.runtime.player.GetComponent<PlayerLoader>().Load(playerData);
            GlobalVar.instance.GameState = GlobalVar.State.Roaming;
            playerData = null;
            loadState = null;
        }
    }
}

