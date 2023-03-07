using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PopUpData", menuName = "Scriptable Objects/Data Containers/Pop Up Data")]
public class PopUpDataScriptableObject : ScriptableObject
{
    public string message;
    public bool isConfirm = false;
    public bool isReadyToClose = false;
    public UnityEvent popUpActionUnityEvent;
}
