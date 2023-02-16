using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
   [SerializeField] private  SoundData soundData;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
           GameMangerRootMaster.instance.audioManager.PlayAudio(soundData);
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            GameMangerRootMaster.instance.audioManager.StopAudio(soundData);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            GameMangerRootMaster.instance.audioManager.SetAudioLoop(soundData, false);
        }
    }
}
