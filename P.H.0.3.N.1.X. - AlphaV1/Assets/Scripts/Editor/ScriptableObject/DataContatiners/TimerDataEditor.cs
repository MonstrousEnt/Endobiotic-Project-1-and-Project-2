/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 7, 2023
 * Last Updated: March 30, 2023
 * Description: This is the editor class for Scriptable Object data container timer data.
 * Notes: 
 * Resources: 
 *	Fight That OCD (CUSTOM INSPECTOR Unity): https://youtu.be/xFtFWmiW7IE
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TimerDataScriptableObject), true)]
public class TimerDataEditor : Editor
{
    #region Class Variables
        #region Serialized Property
        SerializedProperty m_timerModeSerializedProperty;
        #endregion
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        #region Find Serialized Properties
        m_timerModeSerializedProperty = serializedObject.FindProperty("m_timerMode");
        #endregion
    }
    #endregion

    #region Custom Editor View
    public override void OnInspectorGUI()
    {
        //Local Variables
        TimerDataScriptableObject l_timerData = (TimerDataScriptableObject)target;

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
        l_timerData.timeInSeconds = EditorGUILayout.FloatField("Time In Seconds", l_timerData.timeInSeconds);
        EditorGUILayout.PropertyField(m_timerModeSerializedProperty, new GUIContent("Timer Mode"));
        l_timerData.startTimeInSeconds = EditorGUILayout.FloatField("Start Time In Seconds", l_timerData.startTimeInSeconds);
        l_timerData.startTimer = EditorGUILayout.Toggle("Start Timer", l_timerData.startTimer);
        l_timerData.updateUI = EditorGUILayout.Toggle("Update UI", l_timerData.updateUI);

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project 
        EditorUtility.SetDirty(target);

        //Draws default ui (testing only)
        //base.OnInspectorGUI();
    }
    #endregion
}
