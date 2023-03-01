using UnityEngine;

//Animation state machine based off of Lost Relic Games' tutorial: https://www.youtube.com/watch?v=nBkiSJ5z-hE

public class EnemyControllerAnimations : BaseControllerAnimations
{
    private string m_currentAnimaton;
    private string m_LastMoveDir = "D";
    private float m_turnThresholdMoveY = 0.71f;

    private const string m_IDLE_DOWN = "Idle_Down";
    private const string m_IDLE_UP = "Idle_Up";
    private const string m_IDLE_LEFT = "Idle_Left";
    private const string m_IDLE_RIGHT = "Idle_Right";

    private const string m_WALK_DOWN = "Walk_Down";
    private const string m_WALK_UP = "Walk_Up";
    private const string m_WALK_LEFT = "Walk_Left";
    private const string m_WALK_RIGHT = "Walk_Right";

    private Vector3 m_previousPosition;

    private void Start()
    {
        m_previousPosition = transform.position;
    }

    private void Update()
    {
        //enemy based movement detection
        Vector3 deltaMovement = transform.position - m_previousPosition;
        Vector2 changeInPosition = new Vector2(deltaMovement.x, deltaMovement.y);
        MovementAnimation(changeInPosition);
        m_previousPosition = transform.position;
    }

    /// <summary>
    /// Checking for movement to animate based on input, 
    /// using turn threshold values to determine when the sprite will change direction on y axis
    /// </summary>
    /// <param name="movement"></param>
    private void MovementAnimation(Vector2 movement)
    {
        if(m_animator == null)
        {
            return;
        }

        if (movement.y <= -0.01f && Mathf.Abs(movement.x) < m_turnThresholdMoveY)
        {
            ChangeAnimationState(m_WALK_DOWN);
            m_LastMoveDir = "D";
        }
        else if (movement.y >= 0.01f && Mathf.Abs(movement.x) < m_turnThresholdMoveY)
        {
            ChangeAnimationState(m_WALK_UP);
            m_LastMoveDir = "U";
        }
        else if (movement.x <= -0.01f)
        {
            ChangeAnimationState(m_WALK_LEFT);
            m_LastMoveDir = "L";
        }
        else if (movement.x >= 0.01f)
        {
            ChangeAnimationState(m_WALK_RIGHT);
            m_LastMoveDir = "R";
        }

        //Idle
        else
        {
            if (m_LastMoveDir == "D")
                ChangeAnimationState(m_IDLE_DOWN);
            else if (m_LastMoveDir == "U")
                ChangeAnimationState(m_IDLE_UP);
            else if (m_LastMoveDir == "L")
                ChangeAnimationState(m_IDLE_LEFT);
            else if (m_LastMoveDir == "R")
                ChangeAnimationState(m_IDLE_RIGHT);
        }

    }

    // mini animation manager
    /// <summary>
    /// Function to tell the animator to play the animation parameter we give it
    /// </summary>
    /// <param name="newAnimation"></param>
    private void ChangeAnimationState(string newAnimation)
    {
        //prevent the animation from interrupting itself
        if (m_currentAnimaton == newAnimation) return;
        //play the animation
        m_animator.Play(newAnimation);
        //reassign the current state
        m_currentAnimaton = newAnimation;
    }
}
