/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 14, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the scriptable object data container class for pop up data.
 * Notes: 
 * Resources: 
 *  Unite Austin 2017 - Game Architecture with Scriptable Objects: https://youtu.be/raQ3iHhE_Kk
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PopUpData", menuName = "Scriptable Objects/Data Containers/Pop Up Data")]
public class PopUpDataScriptableObject : ScriptableObject
{
    #region Class Variables 
    [SerializeField] private string m_message;
    [SerializeField] private bool m_isConfirm = false;
    [SerializeField] private bool m_isReadyToClose = false;
    [SerializeField] private UnityEvent m_popUpActionUnityEvent;
    #endregion

    #region Getters and Setters
    public string message { get { return m_message; } set { m_message = value; } }
    public bool isConfirm { get { return m_isConfirm; } set { m_isConfirm = value; } }
    public bool isReadyToClose { get { return m_isReadyToClose; } set { m_isReadyToClose = value; } }
    public UnityEvent popUpActionUnityEvent { get { return m_popUpActionUnityEvent; } set { m_popUpActionUnityEvent = value; } }
    #endregion
}

