/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 17, 2023
 * Last Updated: April 2, 2023
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

    [Header("Unity Event")]
    [SerializeField]private UnityEvent<GameObject> m_deathEvent;
    #endregion

    #region Getters and Setters
    public UnityEvent<GameObject> deathEvent { get { return m_deathEvent; } }
    #endregion

    #region Unity Methods
    private void Awake()
    {
        m_characterFormsController = GetComponent<CharacterFormsController>();
        m_deathEvent = new UnityEvent<GameObject>();
    }
    #endregion

    #region AI Interaction Methods
    public void KillEnemy()
    {
        if (m_characterFormsController.currForm != Form.crab)
        {
            return;
        }

        m_deathEvent?.Invoke(this.gameObject);

        Destroy(this.gameObject);
    }

    public void DestroyEnemy()
    {
        m_deathEvent?.Invoke(this.gameObject);

        Destroy(this.gameObject);
    }
    #endregion
}
