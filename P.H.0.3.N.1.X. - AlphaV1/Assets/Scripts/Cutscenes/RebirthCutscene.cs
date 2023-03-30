/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 18, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the class for rebirth Cutscene.
 * Notes: 
 * Resources: 
 *  
 */

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
