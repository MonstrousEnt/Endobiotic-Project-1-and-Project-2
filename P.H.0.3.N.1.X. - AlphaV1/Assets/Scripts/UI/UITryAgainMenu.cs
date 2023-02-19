using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITryAgainMenu : MonoBehaviour
{

    [SerializeField] private PopUpData popUpDataQuitPopUp;

    [SerializeField]  private GameObject mainWindowGameObject;

    [SerializeField] private UIPiontSystem piontSystem;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.activeTryAgainMneuUnityEvent.AddListener(activeTryAgainMneu);
    }
    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.activeTryAgainMneuUnityEvent.RemoveListener(activeTryAgainMneu);
    }

    private void activeTryAgainMneu(bool activeFlag)
    {
        GameMangerRootMaster.instance.uIEvents.InvokeActiveFadeBackground(activeFlag);
        GameMangerRootMaster.instance.uIEvents.tryAgainIsActive = activeFlag;
        piontSystem.DisplayPoints();
        mainWindowGameObject.SetActive(activeFlag);
    }

    public void TryAgin()
    {
        activeTryAgainMneu(false);

        GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);

        GameMangerRootMaster.instance.levelManager.Level1Restart();

        GameMangerRootMaster.instance.levelManager.InvokeLoadNextLevelUnityEvent(LevelName.BenDebugScene);
    }

    public void OepnQuitPopUp()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeSetPopUpData(popUpDataQuitPopUp);

        GameMangerRootMaster.instance.uIEvents.InvokeActivePopUp(true);
    }
}
