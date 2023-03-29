/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 12, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the UI class for start screen.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIStartScreen : MonoBehaviour
{
    #region Class Variables
    [Header("Unity Event")]
    [SerializeField] private UnityEvent m_startSoundtrackUnityEvent;
    [SerializeField] private UnityEvent m_stopSoundtrackUnityEvent;
    [SerializeField] private UnityEvent m_loadNextScenceUnityEvent;
    #endregion

    #region Unity Methods
    private void Start()
    {
        m_startSoundtrackUnityEvent?.Invoke();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            m_stopSoundtrackUnityEvent?.Invoke();
            m_loadNextScenceUnityEvent?.Invoke();
        }
    }
    #endregion
}
