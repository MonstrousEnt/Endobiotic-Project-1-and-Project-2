using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITryAgainMenu : MonoBehaviour
{

    [SerializeField] private PopUpData popUpDataQuitPopUp;

    [SerializeField]  private GameObject mainWindowGameObject;



    // Start is called before the first frame update
    void Start()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);
        activeTrigAgainMneu(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);
            activeTrigAgainMneu(false);
        }
    }

    private void activeTrigAgainMneu(bool activeFlag)
    {
        GameMangerRootMaster.instance.uIEvents.InvokeActiveFadeBackground(activeFlag);
        mainWindowGameObject.SetActive(activeFlag);
    }

    public void TryAgin()
    {
        activeTrigAgainMneu(false);

        GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);

        GameMangerRootMaster.instance.levelManager.Level1Restart();

        GameMangerRootMaster.instance.levelLoaderManger.LoadNextLevel(LevelName.MainLevel);
    }

    public void OepnQuitPopUp()
    {
        GameMangerRootMaster.instance.settingsManager.ActivePause(true, 0f);

        GameMangerRootMaster.instance.uIEvents.InvokeSetPopUpData(popUpDataQuitPopUp);

        GameMangerRootMaster.instance.uIEvents.InvokeActivePopUp(true);
    }
}
