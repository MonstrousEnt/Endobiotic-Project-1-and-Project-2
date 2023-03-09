using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartLevelGameManager : MonoBehaviour
{
    [Header("Time Data")]
    [SerializeField] private TimerDataScriptableObject m_timeData;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent m_soundEffectUnityEvent;

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
