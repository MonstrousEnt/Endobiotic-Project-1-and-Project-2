using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPopUp : MonoBehaviour
{
    [Header("PopUpData Info")]
    [SerializeField] private PopUpData popUpData;

    [Header("UI Componets")]
    [SerializeField] private GameObject MainWindowGameObject;
    [SerializeField] private TextMeshProUGUI messgesTextBox;
    [SerializeField] private GameObject YesButtonGameObject;
    [SerializeField] private GameObject NoButtonGameObject;

    private void Start()
    {
        GameMangerRootMaster.instance.uIEvents.setPopUpDataUnityEvent.AddListener(setPopUpData);
        GameMangerRootMaster.instance.uIEvents.activePopUpUnityEvent.AddListener(activePopUp);
    }

    private void Update()
    {
        if (Input.anyKey)
        {
            if (popUpData != null)
            {
                if (popUpData.isReadyToClose)
                {
                    GameMangerRootMaster.instance.settingsManager.ActivePause(false, 1f);
                    activePopUp(false);
                }
            }
        }
    }


    private void setPopUpData(PopUpData popUpData)
    {
        this.popUpData = null;

        this.popUpData = popUpData;
    }

    private void activePopUp(bool activeFlag)
    {
        displayPopUpData();
        MainWindowGameObject.SetActive(activeFlag);
    }

    private void displayPopUpData()
    {
        if (popUpData != null)
        {
            cleanUIData();

            messgesTextBox.text = popUpData.message;

            if (popUpData.isConfirm)
            {
                YesButtonGameObject.SetActive(true);
                NoButtonGameObject.SetActive(true);
            }
        }
    }

    private void cleanUIData()
    {
        messgesTextBox.text = "";
        YesButtonGameObject.SetActive(false);
        NoButtonGameObject.SetActive(false);
    }

    public void YesActionPopUpOnClick()
    {
        if (popUpData != null)
        {
            popUpData.popUpActionUnityEvent.Invoke();
        }
    }

    private void OnDestroy()
    {
        GameMangerRootMaster.instance.uIEvents.activePopUpUnityEvent.RemoveListener(activePopUp);
        GameMangerRootMaster.instance.uIEvents.setPopUpDataUnityEvent.RemoveListener(setPopUpData);
    }
}
