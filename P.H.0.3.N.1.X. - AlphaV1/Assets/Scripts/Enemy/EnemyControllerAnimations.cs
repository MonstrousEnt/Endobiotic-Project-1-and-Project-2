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
