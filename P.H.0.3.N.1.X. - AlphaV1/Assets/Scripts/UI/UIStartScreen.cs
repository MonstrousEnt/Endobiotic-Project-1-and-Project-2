using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartScreen : MonoBehaviour
{
    [SerializeField] private SoundData m_soundDataTitleScreen;
    [SerializeField] private LevelDataScriptableObject m_levelDataLevel01;

    private void Start()
    {
        GameMangerRootMaster.instance.audioManager.ResetSound();
        GameMangerRootMaster.instance.audioManager.SetAudioLoop(m_soundDataTitleScreen, true);
        GameMangerRootMaster.instance.audioManager.PlayAudio(m_soundDataTitleScreen);
    }

    void Update()
    {
        //stop the start screen soundtrack and load next level when the user press any key
        if (Input.anyKeyDown)
        {
            GameMangerRootMaster.instance.audioManager.SetAudioLoop(m_soundDataTitleScreen, false);
            GameMangerRootMaster.instance.audioManager.StopAudio(m_soundDataTitleScreen);
            GameMangerRootMaster.instance.levelManager.InvokeLoadNextLevelUnityEvent(m_levelDataLevel01.buildindex);
        }
    }
}
