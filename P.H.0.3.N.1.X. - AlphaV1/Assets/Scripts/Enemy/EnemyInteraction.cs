/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 17, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the class for enemy interaction.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;
using UnityEngine.Events;

public class EnemyInteraction : MonoBehaviour
{
    // TODO this class is unfinished and unused

    #region Class Variables
    //Components  
    private EnemyControllerAnimations m_enemyControllerAnimations;
    private CharacterFormsController m_characterFormsController;

    //Unity Events
    public UnityEvent<GameObject> deathEvent;
    #endregion

    #region Unity Methods
    private void Awake()
    {
        m_characterFormsController = GetComponent<CharacterFormsController>();
        deathEvent = new UnityEvent<GameObject>();
    }
    #endregion

    #region AI Interaction Methods
    public void KillEnemy()
    {
        if (m_characterFormsController.currForm != Form.Crab)
        {
            return;
        }

        deathEvent?.Invoke(this.gameObject);

        Destroy(this.gameObject);
    }

    public void DestroyEnemy()
    {
        deathEvent?.Invoke(this.gameObject);

        Destroy(this.gameObject);
    }
    #endregion
}
