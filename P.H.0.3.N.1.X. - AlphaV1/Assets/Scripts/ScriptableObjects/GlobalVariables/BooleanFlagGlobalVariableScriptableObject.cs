using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BooleanFlagGlobalVariable", menuName = "Scriptable Objects/Global Variables/Boolean Flag")]
public class BooleanFlagGlobalVariableScriptableObject : ScriptableObject
{
    #region Class Variables
    [Header("Boolean Flag Data")]
    [SerializeField] private bool m_boolFag;
    #endregion

    #region Getters and Setters
    public void EnableBoolFlag()
    {
        m_boolFag = true;
    }

    public void DisableBooleanFlag()
    {
        m_boolFag = false;
    }

    public bool GetBooleanFlag()
    {
        return m_boolFag;
    }
    #endregion
}
