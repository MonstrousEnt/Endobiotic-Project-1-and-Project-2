using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelDataGameEventListener : MonoBehaviour
{
    [SerializeField] private LevelDataGameEventScriptableObject m_gameEvent;
    [SerializeField] private UnityEvent<LevelDataScriptableObject> m_respone;

    private void OnEnable()
    {
        m_gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        m_gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(LevelDataScriptableObject levelData)
    {
        m_respone.Invoke(levelData);
    }
}
