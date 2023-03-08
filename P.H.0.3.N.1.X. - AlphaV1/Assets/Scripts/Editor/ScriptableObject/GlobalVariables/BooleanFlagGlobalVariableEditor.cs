using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BooleanFlagGlobalVariableScriptableObject), true)]
public class BooleanFlagGlobalVariableEditor : Editor
{
    public override void OnInspectorGUI()
    {
        //Load Variables
        BooleanFlagGlobalVariableScriptableObject booleanFlagGlobalVariable = (BooleanFlagGlobalVariableScriptableObject)target;

        //Update the serialized object in the inspector
        serializedObject.Update();

        //Script reference
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((BooleanFlagGlobalVariableScriptableObject)target), typeof(BooleanFlagGlobalVariableScriptableObject), false);
        GUI.enabled = true;

        //Make a space in the editor
        EditorGUILayout.Space();

        //Create a tile section 
        GUILayout.Label("Boolean Flag Global Variable", EditorStyles.boldLabel);

        //User Input
        booleanFlagGlobalVariable.booleanFlag = EditorGUILayout.Toggle("Boolean Flag", booleanFlagGlobalVariable.booleanFlag);

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project 
        EditorUtility.SetDirty(target);

        //Draws default ui (testing only)
        //base.OnInspectorGUI();
    }
}
