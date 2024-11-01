using System;
using UnityEngine;

public interface ISaveable
{ 
    public void Save(string saveName);
    public void Load(string saveName);
}

public class SaveGame : MonoBehaviour
{
    public const string saveName = "Save";
    public string savestring = "hello";

    public static Action<string> OnSaveEvent;
    public static Action<string> OnLoadEvent;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) // K for Ksave
        {
            Save();
        }

        if(Input.GetKeyDown(KeyCode.L)) // L for Load
        {
            Load();
        }
    }

    public void Save()
    {
        Debug.Log("Saving...");
        PlayerPrefs.SetString(saveName, savestring);

        OnSaveEvent.Invoke(saveName);

        PlayerPrefs.Save();
        Debug.Log("Saved!");
    }

    public void Load()
    {
        Debug.Log("Loading...");

        if(PlayerPrefs.HasKey(saveName))
        {
            OnLoadEvent.Invoke(saveName);
            string loaded = PlayerPrefs.GetString(saveName);
            Debug.Log("Loaded! " + loaded);
        }

    }
}
