using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemTable))]
public class ItemTableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if(GUILayout.Button("Assign IDs"))
        {
            ((ItemTable)target).AssignItemIDs();
        }

        DrawDefaultInspector();
    }
}
