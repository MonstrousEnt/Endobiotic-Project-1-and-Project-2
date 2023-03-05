using UnityEngine;

//Notes Reference: Animation state machine based off of Lost Relic Games' tutorial: https://www.youtube.com/watch?v=nBkiSJ5z-hE

public class EnemyControllerAnimations : BaseControllerAnimations
{
    #region Class Variables 
    private Vector3 m_previousPosition;
    #endregion

    #region Unity Methods
    private void Start()
    {
        m_LastMoveDir = m_moveDir.down;

        m_previousPosition = transform.position;
    }

    private void Update()
    {
        //Enemy based movement detection
        Vector3 deltaMovement = transform.position - m_previousPosition;
        Vector2 changeInPosition = new Vector2(deltaMovement.x, deltaMovement.y);
        CallMovementAnimation(changeInPosition);
        m_previousPosition = transform.position;
    }
    #endregion
}
