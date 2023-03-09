using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TimerDataScriptableObject), true)]
public class TimerDataEditor : Editor
{
    #region Serialized Property
    private SerializedProperty m_timeInSecondsSerializedProperty;
    private SerializedProperty m_startTimerSerializedProperty;
    private SerializedProperty m_UpdateUISerializedProperty;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        #region Find Serialized Properties
        m_timeInSecondsSerializedProperty = serializedObject.FindProperty("m_timeInSeconds");
        m_startTimerSerializedProperty = serializedObject.FindProperty("m_startTimer");
        m_UpdateUISerializedProperty = serializedObject.FindProperty("m_UpdateUI");
        #endregion
    }
    #endregion

    #region Custom Editor View
    public override void OnInspectorGUI()
    {
        //Load Variables
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
        EditorGUILayout.PropertyField(m_timeInSecondsSerializedProperty, new GUIContent("Time In Seconds"));
        EditorGUILayout.PropertyField(m_startTimerSerializedProperty, new GUIContent("Start Timer"));
        EditorGUILayout.PropertyField(m_UpdateUISerializedProperty, new GUIContent("Update UI"));

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project 
        EditorUtility.SetDirty(target);

        //Draws default ui (testing only)
        //base.OnInspectorGUI();
    }
    #endregion
}
