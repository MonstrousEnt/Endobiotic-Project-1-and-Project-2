using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBase : MonoBehaviour
{
    [SerializeField] protected GameObject m_mainWindowGameObject;

    protected void EnableMainWindow()
    {
        m_mainWindowGameObject.SetActive(true);
    }

    protected void DisableMainWindow()
    {
        m_mainWindowGameObject.SetActive(false);
    }
}
