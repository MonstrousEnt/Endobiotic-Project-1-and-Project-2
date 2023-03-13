/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 3, 2023
 * Last Updated: Match 12, 2023
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
    [Header("Time Data")]
    [SerializeField] private TimerDataScriptableObject m_timeData;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent m_soundEffectUnityEvent;
    #endregion

    #region unity Methods
    private void Start()
    {
        startlevel();
    }
    #endregion

    #region Private Start Level Methods
    private void startlevel()
    {
        m_soundEffectUnityEvent.Invoke();

        m_timeData.EnableTime();
    }
    #endregion
}
