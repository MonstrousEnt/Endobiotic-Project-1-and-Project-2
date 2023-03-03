using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [Header("Main Window Data")]
    [SerializeField] protected GameObject m_mainWindowGameObject;

    /// <summary>
    /// Enable the main window.
    /// </summary>
    protected void EnableMainWindow()
    {
        m_mainWindowGameObject.SetActive(true);
    }

    /// <summary>
    /// Disable the main window.
    /// </summary>
    protected void DisableMainWindow()
    {
        m_mainWindowGameObject.SetActive(false);
    }
}