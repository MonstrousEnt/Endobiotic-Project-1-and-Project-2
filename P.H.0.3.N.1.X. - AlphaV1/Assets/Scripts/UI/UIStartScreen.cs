using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIStartScreen : MonoBehaviour
{
   [SerializeField] private UnityEvent m_unityEventStartSoundtrack;
   [SerializeField] private UnityEvent m_unityEventStartGame;


    private void Start()
    {
        m_unityEventStartSoundtrack.Invoke();
    }

    void Update()
    {
        //stop the start screen soundtrack and load next level when the user press any key
        if (Input.anyKeyDown)
        {
            m_unityEventStartGame.Invoke();
        }
    }
}
