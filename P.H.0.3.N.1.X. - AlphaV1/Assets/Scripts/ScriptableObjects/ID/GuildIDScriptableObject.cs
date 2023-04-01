/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 2, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the scriptable object id class for guild id.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "GuildID", menuName = "Scriptable Objects/ID/Guild ID")]
public class GuildIDScriptableObject : ScriptableObject
{
    #region Class Variables
    [SerializeField] private string m_guildID;
    #endregion

    #region Generate Methods
    public void GenerateID()
    {
        m_guildID = Guid.NewGuid().ToString();
    }
    #endregion
}
