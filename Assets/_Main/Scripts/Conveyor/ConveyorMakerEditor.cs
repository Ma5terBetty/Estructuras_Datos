using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor (typeof(ConveyorTool))]
public class ConveyorMakerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ConveyorTool data = (ConveyorTool)target;
        if (GUILayout.Button("Create Conveyors Belts"))
        {
            data.Build(data.amount);
        }


    }
}
