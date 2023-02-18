using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStartScreen : MonoBehaviour
{

    [SerializeField] private SoundData soundDataTitleScreen;

    private void Start()
    {
        GameMangerRootMaster.instance.audioManager.SetAudioLoop(soundDataTitleScreen, true);
        GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataTitleScreen);
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            GameMangerRootMaster.instance.audioManager.SetAudioLoop(soundDataTitleScreen, false);
            GameMangerRootMaster.instance.audioManager.StopAudio(soundDataTitleScreen);

            //open level one
            GameMangerRootMaster.instance.levelManager.InvokeLoadNextLevelUnityEvent(LevelName.MainLevel);


        }
    }
}
