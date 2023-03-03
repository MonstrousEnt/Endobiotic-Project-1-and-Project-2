using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartScreen : MonoBehaviour
{
    [SerializeField] private AudioDataScriptableObject audioDataStartScreenSooundtrack;
    [SerializeField] private LevelDataScriptableObject m_levelDataLevel01;

    private void Start()
    {
        audioDataStartScreenSooundtrack.EnableLoop();
        audioDataStartScreenSooundtrack.PlaySound();
    }

    void Update()
    {
        //stop the start screen soundtrack and load next level when the user press any key
        if (Input.anyKeyDown)
        {

            audioDataStartScreenSooundtrack.StopSound();

            GameMangerRootMaster.instance.levelManager.InvokeLoadNextLevelUnityEvent(m_levelDataLevel01.buildindex);
        }
    }
}
