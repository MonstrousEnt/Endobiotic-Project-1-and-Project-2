using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    //[SerializeField] private SoundData m_soundDataGameMusic;
    [SerializeField] private TimerDataScriptableObject m_timeData;

    private void Start()
    {
        startlevel();
    }

    private void startlevel()
    {
        //GameMangerRootMaster.instance.audioManager.ResetSound();
        //GameMangerRootMaster.instance.audioManager.SetAudioLoop(m_soundDataGameMusic, true);
        //GameMangerRootMaster.instance.audioManager.PlayAudio(m_soundDataGameMusic);

        m_timeData.EnableTime();
    }
}
