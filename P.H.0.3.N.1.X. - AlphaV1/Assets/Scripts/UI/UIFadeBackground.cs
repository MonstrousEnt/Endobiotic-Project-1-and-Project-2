using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeBackground : MonoBehaviour
{
   [SerializeField] private  GameObject m_fadeBackgroundGameObject;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.enableFadeBackgroundUnityEvent.AddListener(enableFadeBackground);
        GameMangerRootMaster.instance.uIEvents.disableFadeBackgroundUnityEvent.AddListener(disableFadeBackground);
    }
    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.enableFadeBackgroundUnityEvent.RemoveListener(enableFadeBackground);
        GameMangerRootMaster.instance.uIEvents.disableFadeBackgroundUnityEvent.RemoveListener(disableFadeBackground);
    }

    /// <summary>
    /// Enable a fade background.
    /// </summary>
    private void enableFadeBackground()
    {
        m_fadeBackgroundGameObject.SetActive(true);
    }

    /// <summary>
    /// Disable a fade background.
    /// </summary>
    private void disableFadeBackground()
    {
        m_fadeBackgroundGameObject.SetActive(false);
    }
}
