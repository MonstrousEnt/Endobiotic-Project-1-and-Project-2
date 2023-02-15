using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeGame : MonoBehaviour
{
   [SerializeField] private  GameObject FadeBackground;

    private void Awake()
    {
        GameMangerRootMaster.instance.uIEvents.activeFadeBackgroundUnityEvents.AddListener(activeFadeBackground);
    }

    private void activeFadeBackground(bool activeFlag)
    {
        FadeBackground.SetActive(activeFlag);
    }

    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.activeFadeBackgroundUnityEvents.RemoveListener(activeFadeBackground);
    }
}
