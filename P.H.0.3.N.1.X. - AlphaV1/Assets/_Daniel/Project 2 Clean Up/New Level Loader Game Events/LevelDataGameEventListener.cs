using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelDataGameEventListener : MonoBehaviour
{
    public LevelDataGameEventScriptableObject gameEvent;
    public UnityEvent<LevelDataScriptableObject> respone;

    private void OnEnable()
    {
        gameEvent.RegisterListener(this);
    }

    private void OnDisable()
    {
        gameEvent.UnregisterListener(this);
    }

    public void OnEventRaised(LevelDataScriptableObject levelData)
    {
        respone.Invoke(levelData);
    }
}
