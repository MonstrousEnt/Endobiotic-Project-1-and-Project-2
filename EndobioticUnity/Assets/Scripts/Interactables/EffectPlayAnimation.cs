/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 18, 2023
 * Last Updated: April 2, 2023
 * Description: This effect class is for play any animation.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;

public class EffectPlayAnimation : MonoBehaviour
{
    #region Class Variables 
    [Header("Animation States")]
    [SerializeField] private string m_animationName = "";
    #endregion

    #region Animation Methods
    public void PlayAnimation()
    {
        if (TryGetComponent(out Animator a_animator))
        {
            a_animator.Play(m_animationName);
        }
    }
    #endregion
}
