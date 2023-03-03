using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartScreen : MonoBehaviour
{
    [SerializeField] private AudioDataScriptableObject audioDataStartScreenSooundtrack;
    [SerializeField] private LevelDataScriptableObject m_levelDataLevel01;

    [SerializeField] private AudioSource m_audioSourceStartScreenSoundTrack;


    private void Start()
    {
        audioDataStartScreenSooundtrack.EnableLoop();
        audioDataStartScreenSooundtrack.PlaySound(m_audioSourceStartScreenSoundTrack);
    }

    void Update()
    {
        //stop the start screen soundtrack and load next level when the user press any key
        if (Input.anyKeyDown)
        {

            audioDataStartScreenSooundtrack.StopSound(m_audioSourceStartScreenSoundTrack);

            GameMangerRootMaster.instance.levelManager.InvokeLoadNextLevelUnityEvent(m_levelDataLevel01.buildindex);
        }
    }
}
