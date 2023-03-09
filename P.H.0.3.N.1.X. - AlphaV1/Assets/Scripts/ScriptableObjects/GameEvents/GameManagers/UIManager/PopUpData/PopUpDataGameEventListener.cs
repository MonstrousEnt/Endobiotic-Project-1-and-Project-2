using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PopUpDataGameEventListener : MonoBehaviour
{
    [SerializeField] private PopUpDataGameEventScriptableObject m_gameEvent;
    [SerializeField] private UnityEvent<PopUpDataScriptableObject> m_respone;

    private void OnEnable()
    {
        m_gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(PopUpDataScriptableObject popUpData)
    {
        m_respone.Invoke(popUpData);
    }
}
