using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveable
{
    public void Save();
    public void Load();
}

public class SaveGame : MonoBehaviour
{
    //private static SaveGame instance;
    //public static SaveGame Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //            instance = FindFirstObjectByType<SaveGame>();
    //        return instance;
    //    }
    //    private set { instance = value; }
    //}

    public static event Action onSaveEvent;
    public static event Action onLoadEvent;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K)) // K is for Ksave
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L)) // L is for Load
        {
            Load();
        }
    }

    private void Load()
    {
        Debug.Log("Loading!");

        //try
        //{
            if(onLoadEvent != null)
            {
                onLoadEvent.Invoke();
            }

        //} catch (Exception e)
        //{
        //    Debug.Log("Load failed!");
        //    throw e; // throw it back
        //}

        Debug.Log("Load Success!");
    }

    private void Save()
    {
        Debug.Log("Saving!");

        if (onSaveEvent != null)
        {
            onSaveEvent.Invoke();
        }

        PlayerPrefs.Save();
    }
}
