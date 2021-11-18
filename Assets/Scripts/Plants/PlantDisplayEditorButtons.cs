using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlantDisplay))]
public class PlantDisplayEditorButtons : Editor
{
    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        if (GUILayout.Button("Generate"))
        {
            Debug.Log("Hello world");
        }
    }
}