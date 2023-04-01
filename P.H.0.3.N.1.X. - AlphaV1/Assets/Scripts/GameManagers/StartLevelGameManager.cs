/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 3, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the game manager class for starting the level.
 * Notes: 
 * Resources: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartLevelGameManager : MonoBehaviour
{
    #region Class Variables
    [Header("Unity Event")]
    [SerializeField] private UnityEvent m_startTimerUnityEvent;
    [SerializeField] private UnityEvent m_soundEffectUnityEvent;
    #endregion

    #region Unity Methods
    private void Start()
    {
        startLevel();
    }
    #endregion

    #region Start Level Methods
    private void startLevel()
    {
        m_startTimerUnityEvent?.Invoke();

        m_soundEffectUnityEvent?.Invoke();
    }
    #endregion
}
