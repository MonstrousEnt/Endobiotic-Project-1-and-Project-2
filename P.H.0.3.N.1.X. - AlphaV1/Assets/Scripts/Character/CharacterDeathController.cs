/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 16, 2023
 * Last Updated: Match 29, 2023
 * Description: This is class is for play the player death animation. 
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;

public class CharacterDeathController : BaseControllerAnimations
{
    #region Class Variables
    //Player Death animation
    private const string m_DEATH = "death";
    #endregion

    #region Unity Methods
    private void Start()
    {
        m_animator = GetComponentInChildren<Animator>();
    }
    #endregion

    #region Death Animations
    public void Die()
    {
        ChangeAnimationState(m_DEATH);
    }
    #endregion
}