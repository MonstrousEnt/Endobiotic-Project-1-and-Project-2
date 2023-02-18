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

    private void Start()
    {
        StartCoroutine(IntroCutscene());
    }

    private IEnumerator IntroCutscene()
    {
        GameMangerRootMaster.instance.playerManager.DisableCharacterControls();

        rebirthParticles.Play();

        yield return new WaitForSeconds(2.0f);

        GameMangerRootMaster.instance.playerManager.EnableCharacterControls();
    }
}
