/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox
 * Created Date: February 18, 2023
 * Last Updated: Match 29, 2023
 * Description: This trigger class is for open the try again UI Menu.
 * Notes: 
 * Resources: 
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UITryAgainMenuOpenTrigger : MonoBehaviour
{
    [Header("Unity Events")]
    [SerializeField] private UnityEvent m_enbaleTryAgainMenuUjnityEvent;

    #region Unity Methods
    private void OnTriggerEnter2D(Collider2D a_collision)
    {
        m_enbaleTryAgainMenuUjnityEvent?.Invoke();
    }
    #endregion
}
