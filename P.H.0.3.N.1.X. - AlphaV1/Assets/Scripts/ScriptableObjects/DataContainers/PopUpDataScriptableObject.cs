using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "PopUpData", menuName = "Scriptable Objects/Data Containers/Pop Up Data")]
public class PopUpDataScriptableObject : ScriptableObject
{
    [SerializeField] private string m_message;
    [SerializeField] private bool m_isConfrim = false;
    [SerializeField] private bool m_isReadyToClose = false;
    [SerializeField] private UnityEvent m_popUpActionUnityEvent;

    #region Getters and Setters
    public string message { get { return m_message; } set { m_message = value; } }
    public bool isConfirm { get { return m_isConfrim; } set { m_isConfrim = value; } }
    public bool isReadyToClose { get { return m_isReadyToClose; } set { m_isReadyToClose = value; } }
    public UnityEvent popUpActionUnityEvent { get { return m_popUpActionUnityEvent; } set { m_popUpActionUnityEvent = value; } }
    #endregion
}

