using System.Collections;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    //Fade in
    //Camera pan up
    //Robot wandering aimlessly
    //Play rebirth particles / stop random wandering
    //Allow player control

    [SerializeField] private ParticleSystem rebirthParticles;

    [SerializeField] private SoundData soundDataGameMusic;
    [SerializeField] private TimerData timeData;

    private void Awake()
    {
        
    }

    private void Start()
    {
        GameMangerRootMaster.instance.audioManager.ResetSound();
        timeData.startTime = true;
        timeData.UpdateUI = true;

        StartCoroutine(IntroCutscene());
    }

    private IEnumerator IntroCutscene()
    {
        GameMangerRootMaster.instance.playerManager.DisableCharacterControls();

        // Start sound here
        GameMangerRootMaster.instance.audioManager.SetAudioLoop(soundDataGameMusic, true);
        GameMangerRootMaster.instance.audioManager.PlayAudio(soundDataGameMusic);

        rebirthParticles.Play();

        yield return new WaitForSeconds(2.0f);

        GameMangerRootMaster.instance.playerManager.EnableCharacterControls();
    }
}
