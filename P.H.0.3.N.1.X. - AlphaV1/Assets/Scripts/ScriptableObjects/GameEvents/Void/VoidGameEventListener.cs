using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidGameEventListener : MonoBehaviour
{
    [SerializeField] private VoidGameEventScriptableObject m_gameEvent;
    [SerializeField] private UnityEvent m_respone;

    private void OnEnable()
    {
        m_gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised()
    {
        m_respone.Invoke();
    }
}