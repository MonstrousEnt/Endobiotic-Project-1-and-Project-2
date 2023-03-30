/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: March 29, 2023
 * Last Updated: Match 30, 2023
 * Description: This is the game manager for the Timer
 * Notes: 
 * Resources: 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
   #region Class Variables
   [Header("Time Data")]
   [SerializeField] private TimerDataScriptableObject m_timerData;
   #endregion

   #region Timer Game Events
   public void SetUpTimer(TimerDataScriptableObject a_timerData)
   {
       a_timerData.Reset();

       m_timerData = null;

       this.m_timerData = a_timerData;
   }

   public void EnableTime(TimerDataScriptableObject a_timerData)
   {
       a_timerData.startTimer = true;
       a_timerData.updateUI = true;
   }
   #endregion

   #region Time Mode Methods
   private void UpdataeTimer(TimerDataScriptableObject a_timerData)
   {
       switch (a_timerData.timerMode)
       {
           case TimerMode.CountUp:
           {
               countUpTimer(a_timerData);
               break;
           }
           case TimerMode.CountDown:
           {
               countDownTimer(a_timerData);
               break;
           }
       }
   }

   private void countUpTimer(TimerDataScriptableObject a_timerData)
   {
       a_timerData.timeInseconds += Time.deltaTime;
   }

   private void countDownTimer(TimerDataScriptableObject a_timerData)
   {
       a_timerData.timeInseconds -= Time.deltaTime;
   }
   #endregion

   #region Unity Methods
   private void Update()
   {
       if (m_timerData != null)
       {
           if (m_timerData.startTimer)
           {
               UpdataeTimer(m_timerData);
           }
       }
   }
   #endregion
}
