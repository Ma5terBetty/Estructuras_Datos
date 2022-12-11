#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GraphGenerator))]
public class GraphGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GraphGenerator graphGenerator = (GraphGenerator)target;
        if (GUILayout.Button("Generate Graph"))
        { 
            graphGenerator.GenerateGraph();
        }
    }
}
#endif