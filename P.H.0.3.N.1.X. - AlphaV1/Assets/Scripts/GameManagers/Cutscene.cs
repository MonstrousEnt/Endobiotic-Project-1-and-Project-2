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

    [SerializeField] private BooleanFlagGlobalScriptableObjectVariable m_booleanFlagGlobalVariablePlayerCanMove;

    private void Start()
    {
        StartCoroutine(IntroCutscene());
    }

    private IEnumerator IntroCutscene()
    {
        m_booleanFlagGlobalVariablePlayerCanMove.DisableBooleanFlag();

        rebirthParticles.Play();

        yield return new WaitForSeconds(2.0f);

        m_booleanFlagGlobalVariablePlayerCanMove.EnableBoolFlag();
    }
}
