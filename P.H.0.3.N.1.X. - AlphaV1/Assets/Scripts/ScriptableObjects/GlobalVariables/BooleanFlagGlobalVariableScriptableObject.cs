using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BooleanFlagGlobalVariable", menuName = "Scriptable Objects/Global Variables/Boolean Flag")]
public class BooleanFlagGlobalVariableScriptableObject : ScriptableObject
{
    [SerializeField] private bool m_booleanFlag;

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
