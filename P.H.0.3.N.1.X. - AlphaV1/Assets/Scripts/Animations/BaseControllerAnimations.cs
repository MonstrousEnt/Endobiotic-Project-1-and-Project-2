/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: James Dalziel, Ben Topple, Daniel Cox
 * Created Date: February 17, 2023
 * Last Updated: April 2, 2023
 * Description: This is the base class for player and enemy animations.
 * Notes:
 * Resources: 
 */

using UnityEngine;

public abstract class BaseControllerAnimations : MonoBehaviour
{
    #region Class Variables 
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

    //Components
    protected Animator m_animator;

    //Animations
    protected string m_currentAnimation;
    protected MoveDirection m_LastMoveDir;
    protected float m_turnThresholdMoveY = 0.71f;
    #endregion

    #region Getters and Setters
    public Animator Animator { set { m_animator = value; } }
    #endregion

    #region Mini Animation Manager
    protected virtual void ChangeAnimationState(string a_newAnimation)
    {
        if (m_currentAnimation == a_newAnimation) return;
        m_animator.Play(a_newAnimation);
        m_currentAnimation = a_newAnimation;
    }
    #endregion

    #region Animations Methods
    public void CallMovementAnimation(Vector2 a_movement)
    {
        if (m_animator == null)
        {
            return;
        }

        moveAnimations(a_movement);
    }

    private void idleAnimation()
    {
        switch (m_LastMoveDir)
        {
            case MoveDirection.down:
                ChangeAnimationState(m_IDLE_DOWN);
                break;

            case MoveDirection.up:
                 ChangeAnimationState(m_IDLE_UP);
                break;

            case MoveDirection.left:
                ChangeAnimationState(m_IDLE_LEFT);
                break;

            case MoveDirection.right:
                ChangeAnimationState(m_IDLE_RIGHT);
                break;
        }
    }

    private void moveAnimations(Vector2 a_movement)
    {
        if (a_movement.y <= -0.01f && Mathf.Abs(a_movement.x) < m_turnThresholdMoveY)
        {
            ChangeAnimationState(m_WALK_DOWN);
            m_LastMoveDir = MoveDirection.down;
        }
        else if (a_movement.y >= 0.01f && Mathf.Abs(a_movement.x) < m_turnThresholdMoveY)
        {
            ChangeAnimationState(m_WALK_UP);
            m_LastMoveDir = MoveDirection.up;
        }
        else if (a_movement.x <= -0.01f)
        {
            ChangeAnimationState(m_WALK_LEFT);
            m_LastMoveDir = MoveDirection.left;
        }
        else if (a_movement.x >= 0.01f)
        {
            ChangeAnimationState(m_WALK_RIGHT);
            m_LastMoveDir = MoveDirection.right;
        }
        else
        {
            idleAnimation();
        }
    }
    #endregion
}
