using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PlantDisplay))]
public class PlantDisplayEditorButtons : Editor
{
    public override void OnInspectorGUI() {

        PlantDisplay plantDisplay = (PlantDisplay)target;

        DrawDefaultInspector();
        if (GUILayout.Button("Generate"))
        {
            plantDisplay.GenerateAndDisplayPlant();
        }
    }
}