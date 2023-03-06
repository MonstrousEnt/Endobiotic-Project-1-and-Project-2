using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class UIPopUp : UIBase
{
    [Header("PopUpData Info")]
    [SerializeField] private PopUpData m_popUpData;

    [Header("UI Data")]
    [SerializeField] private TextMeshProUGUI m_messgesTextBox;

    [Header("UI Components")]
    [SerializeField] private GameObject m_yesButtonGameObject;
    [SerializeField] private GameObject m_NoButtonGameObject;
    [SerializeField] private GameObject m_popUpFirstButton;

    #region Setters and Getters
    public void SetPopUpData(PopUpData popUpData)
    {
        this.m_popUpData = null;

        this.m_popUpData = popUpData;
    }
    #endregion

    private void Update()
    {
        //When the pop is ready to close, and if the user press any key, close the pop up.
        if (Input.anyKey)
        {
            if (m_popUpData != null)
            {
                if (m_popUpData.isReadyToClose)
                {
                    DisablePopUp();
                }
            }
        }
    }

    /// <summary>
    /// Enable the pop up and Display Data for the pop up.
    /// </summary>
    public void EnablePopUp()
    {
        displayPopUpData();
        EnableMainWindow();
    }

    /// <summary>
    /// Disable the pop up.
    /// </summary>
    public void DisablePopUp()
    {
        DisableMainWindow();
    }

    /// <summary>
    /// Clean the UI data. Then Display Pop Data
    /// </summary>
    private void displayPopUpData()
    {
        if (m_popUpData != null)
        {
            cleanUIData();

            m_messgesTextBox.text = m_popUpData.message;

            if (m_popUpData.isConfirm)
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(m_popUpFirstButton);

                m_yesButtonGameObject.SetActive(true);
                m_NoButtonGameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Clean the UI Data elements
    /// </summary>
    private void cleanUIData()
    {
        m_messgesTextBox.text = "";
        m_yesButtonGameObject.SetActive(false);
        m_NoButtonGameObject.SetActive(false);
    }

    /// <summary>
    /// When the user click the yes button, invoke the unity event pop up action
    /// </summary>
    public void YesActionPopUpOnClick()
    {
        if (m_popUpData != null)
        {
            m_popUpData.popUpActionUnityEvent.Invoke();
        }
    }
}