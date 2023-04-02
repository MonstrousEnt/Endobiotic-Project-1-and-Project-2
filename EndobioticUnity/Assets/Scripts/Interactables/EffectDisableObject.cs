/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 12, 2023
 * Last Updated: April 2, 2023
 * Description: This effect class is for disable any game object.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;
using UnityEngine.Events;

public class EffectDisableObject : MonoBehaviour
{
    #region Disable Game Object Methods
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
    #endregion
}
