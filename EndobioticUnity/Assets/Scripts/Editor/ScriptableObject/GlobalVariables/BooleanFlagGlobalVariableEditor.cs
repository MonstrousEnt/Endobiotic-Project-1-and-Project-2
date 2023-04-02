/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 7, 2023
 * Last Updated: April 2, 2023
 * Description: This is the editor class for Scriptable Object Global Variables boolean flags.
 * Notes: 
 * Resources: 
 *	Fight That OCD (CUSTOM INSPECTOR Unity): https://youtu.be/xFtFWmiW7IE
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BooleanFlagGlobalVariableScriptableObject), true)]
public class BooleanFlagGlobalVariableEditor : Editor
{
    #region Class Variables
        #region Serialized Property
        private SerializedProperty m_booleanFlagSerializedProperty;
        #endregion
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        #region Find Serialized Properties
        m_booleanFlagSerializedProperty = serializedObject.FindProperty("m_booleanFlag");
        #endregion
    }
    #endregion

    #region Custom Editor View
    public override void OnInspectorGUI()
    {
        //Local Varabiles
        BooleanFlagGlobalVariableScriptableObject l_booleanFlagGlobalVariable = (BooleanFlagGlobalVariableScriptableObject)target;

        serializedObject.Update();

        //Script reference
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((BooleanFlagGlobalVariableScriptableObject)target), typeof(BooleanFlagGlobalVariableScriptableObject), false);
        GUI.enabled = true;

        //Make a space in the editor
        EditorGUILayout.Space();

        //Create a tile section 
        GUILayout.Label("Boolean Flag Global Variable", EditorStyles.boldLabel);

        //User Inputs
        EditorGUILayout.PropertyField(m_booleanFlagSerializedProperty, new GUIContent("Boolean Flag"));

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project
        EditorUtility.SetDirty(target);

        //Draws default ui (testing only)
        //base.OnInspectorGUI();
    }
    #endregion
}
