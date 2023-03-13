/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 4, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the scriptable object tag class for tag data.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TagData", menuName = "Scriptable Objects/Tag/Tag Data")]
public class TagDataScriptableObject : ScriptableObject
{
    #region Class Variables
    [SerializeField] private string m_tagName;
    #endregion

    #region Getters and Setters
    public string tagName { get { return m_tagName; } set { m_tagName = value; } }
    #endregion
}