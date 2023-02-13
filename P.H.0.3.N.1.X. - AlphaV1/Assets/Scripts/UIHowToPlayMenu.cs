using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHowToPlayMenu : MonoBehaviour
{
    [SerializeField] private GameObject mainWindowGameObject;

    private void Awake()
    {
        GameMangerRootMaster.instance.uIEvents.activeHowToPlayMenuUnityEvents.AddListener(activeHowToPlay);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameMangerRootMaster.instance.uIEvents.InvokeActiveFadeBackground(false);
            activeHowToPlay(false);
        }
    }

    private void activeHowToPlay(bool activeFlag)
    {
        GameMangerRootMaster.instance.uIEvents.InvokeActiveFadeBackground(activeFlag);
        mainWindowGameObject.SetActive(activeFlag);
    }


    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.activeHowToPlayMenuUnityEvents.RemoveListener(activeHowToPlay);
    }

}
