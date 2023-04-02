/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 17, 2023
 * Last Updated: April 2, 2023
 * Description: This is the class for character destroyer attack.
 * Notes: 
 * Resources: 
 *  
 */


using UnityEngine;

public class DestroyerFormAttack : MonoBehaviour
{
    #region Class Variables
    [Header("Components")]
    [SerializeField] PlayerControllerAnimations m_playerControllerAnimations;
    #endregion

    #region Unity Methods
    private void Update()
    {
        if (m_playerControllerAnimations == null)
        {
            return;
        }

        if (Input.GetButton("FormAction"))
        {
            m_playerControllerAnimations.DestroyerAttack();
        }
    }
    #endregion
}
