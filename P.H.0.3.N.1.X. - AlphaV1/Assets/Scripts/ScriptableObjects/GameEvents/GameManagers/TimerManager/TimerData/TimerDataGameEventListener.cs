using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerDataGameEventListener : MonoBehaviour
{
    #region Class Variables 
    [Header("Game Event Scriptable Object")]
    [SerializeField] private TimerDataGameEventScriptableObject m_gameEvent;

    [Header("Unity Event")]
    [SerializeField] private UnityEvent<TimerDataScriptableObject> m_respone;
    #endregion

    #region Invoke Unity Events
    public void OnEventRaised(TimerDataScriptableObject timerData)
    {
        m_respone?.Invoke(timerData);
    }
    #endregion

    #region Unity Methods
    private void OnEnable()
    {
        m_gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_gameEvent.UnregisterListener(this);
    }
    #endregion
}
