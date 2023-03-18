using System.Collections;
using UnityEngine;

public class RebirthCutscene : MonoBehaviour
{
    #region Class Methods
    [Header("Special Effect")]
    [SerializeField] private ParticleSystem m_rebirthParticles;

    [Header("Boolean Flag Scriptable Object - Player Manager")]
    [SerializeField] private BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerCanMove;
    #endregion

    #region Unity Methods
    private void Start()
    {
        StartCoroutine(playRebirthCutscene());
    }
    #endregion

    #region Cutscene Methods
    private IEnumerator playRebirthCutscene()
    {
        m_booleanFlagGlobalVariablePlayerCanMove.DisableBooleanFlag();

        m_rebirthParticles.Play();

        yield return new WaitForSeconds(2.0f);

        m_booleanFlagGlobalVariablePlayerCanMove.EnableBoolFlag();
    }
    #endregion
}
