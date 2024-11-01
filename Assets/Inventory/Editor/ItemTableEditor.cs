using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(ItemTable))]
public class ItemTableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Assign IDs"))
        {
            ((ItemTable)target).SetItemIDs();
        }

        DrawDefaultInspector();
    }
}
