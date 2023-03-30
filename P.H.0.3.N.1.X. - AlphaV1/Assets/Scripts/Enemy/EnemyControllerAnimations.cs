/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Daniel Cox
 * Created Date: February 17, 2023
 * Last Updated: Match 29, 2023
 * Description: This is the class for enemy animations.
 * Notes: 
 * Resources: 
 *  
 */

using UnityEngine;

public class EnemyControllerAnimations : BaseControllerAnimations
{
    #region Class Variables
    //Movements  
    private Vector3 m_previousPosition;
    #endregion

    #region Unity Methods
    private void Start()
    {
        m_LastMoveDir = MoveDirection.Down;
        m_previousPosition = transform.position;
    }

    private void Update()
    {
        movementDetection();
       
    }
    #endregion

    #region Animations Methods
    private void movementDetection()
    {
        Vector3 deltaMovement = transform.position - m_previousPosition;
        Vector2 changeInPosition = new Vector2(deltaMovement.x, deltaMovement.y);

        CallMovementAnimation(changeInPosition);

        m_previousPosition = transform.position;
    }
    #endregion
}
