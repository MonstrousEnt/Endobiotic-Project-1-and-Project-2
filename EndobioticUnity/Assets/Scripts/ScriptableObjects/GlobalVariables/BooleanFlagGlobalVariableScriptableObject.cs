/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 5, 2023
 * Last Updated: April 2, 2023
 * Description: This is the scriptable object global variables class for boolean flags.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BooleanFlagGlobalVariable", menuName = "Scriptable Objects/Global Variables/Boolean Flag")]
public class BooleanFlagGlobalVariableScriptableObject : ScriptableObject
{
    #region Class Variables
    [SerializeField] private bool m_booleanFlag;
    #endregion

    #region Getters and Setters
    public bool booleanFlag { get { return m_booleanFlag; } }

    public void EnableBoolFlag()
    {
        m_booleanFlag = true;
    }

    public void DisableBooleanFlag()
    {
        m_booleanFlag = false;
    }
    #endregion
}
