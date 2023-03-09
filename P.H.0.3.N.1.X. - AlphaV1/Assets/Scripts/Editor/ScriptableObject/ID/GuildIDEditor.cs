using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GuildIDScriptableObject), true)]
public class GuildIdEditor : Editor
{
    #region Serialized Property
    private SerializedProperty m_guildIdSerializedProperty;
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        #region Find Serialized Properties
        m_guildIdSerializedProperty = serializedObject.FindProperty("m_id");
        #endregion
    }
    #endregion

    #region Custom Editor View
    public override void OnInspectorGUI()
    {
        //Load Variables 
        GuildIDScriptableObject guildID = (GuildIDScriptableObject)target;

        //Update the serialized object in the inspector
        serializedObject.Update();

        //Script reference
        GUI.enabled = false;
        EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject((GuildIDScriptableObject)target), typeof(GuildIDScriptableObject), false);
        GUI.enabled = true;

        //Make a space in the editor
        EditorGUILayout.Space();

        //Create a tile section 
        GUILayout.Label("Guild Id", EditorStyles.boldLabel);

        //User Input
        EditorGUILayout.PropertyField(m_guildIdSerializedProperty, new GUIContent("ID"));

        EditorGUILayout.Space();

        //Buttons
        if (GUILayout.Button("Gen ID"))
        {
            guildID.GenId();
        }

        //Apply changes
        serializedObject.ApplyModifiedProperties();

        //Save data when using press save project from file dropdown menu in the menutool bar
        EditorUtility.SetDirty(target);

        //Draws default ui (testing only)
        //base.OnInspectorGUI();
    }
    #endregion
}
