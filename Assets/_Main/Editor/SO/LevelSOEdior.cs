using System;
using UnityEditor;

[CustomEditor(typeof(LevelSO))]
public class LevelSOEdior : Editor
{
    #region SerializedProperties

    private SerializedProperty _amountOfOrders;

    #endregion

    private void OnEnable()
    {
        _amountOfOrders = serializedObject.FindProperty("amountOfOrders");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.Space(5);
        EditorGUILayout.LabelField("Level Details", EditorStyles.boldLabel);
        EditorGUILayout.PropertyField(_amountOfOrders);
        
        serializedObject.ApplyModifiedProperties();
    }
}
