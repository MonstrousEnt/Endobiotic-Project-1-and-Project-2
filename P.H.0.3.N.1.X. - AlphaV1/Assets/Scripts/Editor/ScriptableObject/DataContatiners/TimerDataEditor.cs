using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TimerDataScriptableObject), true)]
public class TimerDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TimerDataScriptableObject timerData = (TimerDataScriptableObject)target;

        //Update the serialized object in the inspector
        serializedObject.Update();

        //Script reference
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((TimerDataScriptableObject)target), typeof(TimerDataScriptableObject), false);
        GUI.enabled = true;

        //Make a space in the editor
        EditorGUILayout.Space();

        //Create a tile section
        GUILayout.Label("Timer Data", EditorStyles.boldLabel);

        //User Inputs 
        timerData.timeInseconds = EditorGUILayout.FloatField("Time In Seconds", timerData.timeInseconds);
        timerData.startTimer = EditorGUILayout.Toggle("Start Timer", timerData.startTimer);
        timerData.updateUI = EditorGUILayout.Toggle("Update UI", timerData.updateUI);

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project 
        EditorUtility.SetDirty(target);

        //Draws default ui (testing only)
        //base.OnInspectorGUI();
    }
}
