using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIStartScreen : MonoBehaviour
{

    [SerializeField] private AudioDataScriptableObject audioDataStartScreenSoundtrack;

   [SerializeField] private UnityEvent m_unityEventStartGame;


    private void Start()
    {
        audioDataStartScreenSoundtrack.PlaySound();
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
