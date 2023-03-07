using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BooleanFlagGlobalVariable", menuName = "Scriptable Objects/Global Variables/Boolean Flag")]
public class BooleanFlagGlobalVariableScriptableObject : ScriptableObject
{
    public bool booleanFlag;

    #region Getters and Setters
    public void EnableBoolFlag()
    {
        booleanFlag = true;
    }

    public void DisableBooleanFlag()
    {
        booleanFlag = false;
    }

    public bool GetBooleanFlag()
    {
        return booleanFlag;
    }
    #endregion
}
