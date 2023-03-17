/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 2, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the scriptable object data container class for level data.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Scriptable Objects/Data Containers/Level Data")]
public class LevelDataScriptableObject : ScriptableObject
{
    #region Class Variables
    [SerializeField] private string m_levelID;
    [SerializeField] private string m_levelName;
    [SerializeField] private int m_buildIndex;
    [SerializeField] private bool m_unlockLevel;
    #endregion

    #region Getters and Setters
    public string id { get { return m_levelID; } set { m_levelID = value; } }
    public string levelName { get { return m_levelName; } set { m_levelName = value; } }
    public int buildindex { get { return m_buildIndex; } set { m_buildIndex = value; } }
    public bool unlockLevel { get { return m_unlockLevel; } set { m_unlockLevel = value; } }
    #endregion
}
