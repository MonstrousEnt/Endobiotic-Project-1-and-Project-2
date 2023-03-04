using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartLevel : MonoBehaviour
{
    [SerializeField] private TimerDataScriptableObject m_timeData;

    [SerializeField] private UnityEvent SoundEffectUnityEvent;

    private void Start()
    {
        startlevel();
    }

    private void startlevel()
    {
        SoundEffectUnityEvent.Invoke();

        m_timeData.EnableTime();
    }
}
