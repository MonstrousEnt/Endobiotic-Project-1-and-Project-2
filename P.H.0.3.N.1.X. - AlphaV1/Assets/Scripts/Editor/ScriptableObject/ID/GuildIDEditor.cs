/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 7, 2023
 * Last Updated: March 30, 2023
 * Description: This is the editor class for Scriptable Object ID guild id.
 * Notes: 
 * Resources: 
 *	Fight That OCD (CUSTOM INSPECTOR Unity): https://youtu.be/xFtFWmiW7IE
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GuildIDScriptableObject), true)]
public class GuildIdEditor : Editor
{
    #region Class Variables
        #region Serialized Property
        private SerializedProperty m_guilDIDSerializedProperty;
        #endregion
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        #region Find Serialized Properties
        m_guilDIDSerializedProperty = serializedObject.FindProperty("m_guildID");
        #endregion
    }
    #endregion

    #region Custom Editor View
    public override void OnInspectorGUI()
    {
        //Local Variables
        GuildIDScriptableObject l_guildID = (GuildIDScriptableObject)target;

        //Update the serialized object in the inspector
        serializedObject.Update();

        //Script reference
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((GuildIDScriptableObject)target), typeof(GuildIDScriptableObject), false);
        GUI.enabled = true;

        //Make a space in the editor
        EditorGUILayout.Space();

        //Create a tile section 
        GUILayout.Label("Guild ID", EditorStyles.boldLabel);

        //User Inputs
        EditorGUILayout.PropertyField(m_guilDIDSerializedProperty, new GUIContent("ID"));

        EditorGUILayout.Space();

        //Buttons
        if (GUILayout.Button("Gen ID"))
        {
            l_guildID.GenId();
        }

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project
        EditorUtility.SetDirty(target);

        //Draws default ui (testing only)
        //base.OnInspectorGUI();
    }
    #endregion
}
