/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 19, 2023
 * Last Updated: April 2, 2023
 * Description: This effect class is for disable a Collier 2D of any game object.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using UnityEngine;

public class EffectDisableCollider : MonoBehaviour
{
    #region Class Variables
    [Header("Delay")]
    [SerializeField] private float m_delay = 0;

    [Header("Collier 2D")]
    [SerializeField] private Collider2D m_collider;
    #endregion

    #region Disable Collier Methods
    public void DisableCollider()
    {
        if(m_collider != null)
        {
            StartCoroutine(disableColliderAfterDelay(m_delay));
        }
    }

    private IEnumerator disableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        m_collider.enabled = false;
    }
    #endregion
}
