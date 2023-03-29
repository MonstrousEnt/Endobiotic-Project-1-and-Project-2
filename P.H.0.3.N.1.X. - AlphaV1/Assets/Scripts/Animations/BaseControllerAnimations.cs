/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Ben Topple, Daniel Cox
 * Created Date: February 17, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the base class for player and enemy animations.
 * Notes:
 * Resources: 
 */

using UnityEngine;

public class BaseControllerAnimations : MonoBehaviour
{
    #region Class Variables 
    [Header("Components")]
    protected Animator m_animator;

    [Header("Animation")]
    protected string m_currentAnimaton;
    protected MoveDirection m_LastMoveDir;
    protected float m_turnThresholdMoveY = 0.71f;

    //To Do create these animations states into Unity Scriptable Object data container
    [Header("Animation States - Idle")] 
    [SerializeField] protected string m_IDLE_DOWN = "Idle_Down";
    [SerializeField] protected string m_IDLE_UP = "Idle_Up";
    [SerializeField] protected string m_IDLE_LEFT = "Idle_Left";
    [SerializeField] protected string m_IDLE_RIGHT = "Idle_Right";

    [Header("Animation States - Walk")]
    [SerializeField] protected string m_WALK_DOWN = "Walk_Down";
    [SerializeField] protected string m_WALK_UP = "Walk_Up";
    [SerializeField] protected string m_WALK_LEFT = "Walk_Left";
    [SerializeField] protected string m_WALK_RIGHT = "Walk_Right";
    #endregion

    #region Getters and Setters
    public Animator Animator { set { m_animator = value; } }
    #endregion

    #region Mini Animation Manager
    /// <summary>
    /// Function to tell the animator to play the animation parameter we give it.
    /// </summary>
    /// <param name="newAnimation"></param>
    protected virtual void ChangeAnimationState(string newAnimation)
    {
        if (m_currentAnimaton == newAnimation) return;
        m_animator.Play(newAnimation);
        m_currentAnimaton = newAnimation;
    }
    #endregion

    #region Animations Methods
    /// <summary>
    /// Call the move animations.
    /// </summary>
    /// <param name="movement"></param>
    public void CallMovementAnimation(Vector2 movement)
    {
        if (m_animator == null)
        {
            return;
        }

        moveAnimations(movement);
    }

    /// <summary>
    /// Idle animations for the player or enemy.
    /// </summary>
    private void idleAnimation()
    {
        switch (m_LastMoveDir)
        {
            case MoveDirection.Down:
                ChangeAnimationState(m_IDLE_DOWN);
                break;

            case MoveDirection.Up:
                 ChangeAnimationState(m_IDLE_UP);
                break;

            case MoveDirection.Left:
                ChangeAnimationState(m_IDLE_LEFT);
                break;

            case MoveDirection.Right:
                ChangeAnimationState(m_IDLE_RIGHT);
                break;
        }
    }

    /// <summary>
    /// Checking for movement to animate based on input, 
    /// using turn threshold values to determine when the sprite will change direction on y axis.
    /// </summary>
    /// <param name="movement"></param>
    private void moveAnimations(Vector2 movement)
    {
        if (movement.y <= -0.01f && Mathf.Abs(movement.x) < m_turnThresholdMoveY)
        {
            ChangeAnimationState(m_WALK_DOWN);
            m_LastMoveDir = MoveDirection.Down;
        }
        else if (movement.y >= 0.01f && Mathf.Abs(movement.x) < m_turnThresholdMoveY)
        {
            ChangeAnimationState(m_WALK_UP);
            m_LastMoveDir = MoveDirection.Up;
        }
        else if (movement.x <= -0.01f)
        {
            ChangeAnimationState(m_WALK_LEFT);
            m_LastMoveDir = MoveDirection.Left;
        }
        else if (movement.x >= 0.01f)
        {
            ChangeAnimationState(m_WALK_RIGHT);
            m_LastMoveDir = MoveDirection.Right;
        }
        else
        {
            idleAnimation();
        }
    }
    #endregion
}
