using UnityEngine;

public class BaseControllerAnimations : MonoBehaviour
{
    #region Class Variables 
    [Header("Components")]
    protected Animator m_animator;

    [Header("Animation")]
    protected string m_currentAnimaton;
    protected m_moveDir m_LastMoveDir;
    protected float m_turnThresholdMoveY = 0.71f;

    //Enum Animation
    protected enum m_moveDir
    {
        down,
        up,
        left,
        right
    }

    //To Do create these animations states into Unity Scriptable Object data container
    [Header("Animation States - Idle")] 
    [SerializeField] protected const string m_IDLE_DOWN = "Idle_Down";
    [SerializeField] protected const string m_IDLE_UP = "Idle_Up";
    [SerializeField] protected const string m_IDLE_LEFT = "Idle_Left";
    [SerializeField] protected const string m_IDLE_RIGHT = "Idle_Right";

    [Header("Animation States - Walk")]
    [SerializeField] protected const string m_WALK_DOWN = "Walk_Down";
    [SerializeField] protected const string m_WALK_UP = "Walk_Up";
    [SerializeField] protected const string m_WALK_LEFT = "Walk_Left";
    [SerializeField] protected const string m_WALK_RIGHT = "Walk_Right";
    #endregion

    #region Getters and Setters
    public void SetAnimator(Animator newAnimator) { m_animator = newAnimator; }
    #endregion

    #region mini animation manager
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
            case m_moveDir.down:
                ChangeAnimationState(m_IDLE_DOWN);
                break;

            case m_moveDir.up:
                 ChangeAnimationState(m_IDLE_UP);
                break;

            case m_moveDir.left:
                ChangeAnimationState(m_IDLE_LEFT);
                break;

            case m_moveDir.right:
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
            m_LastMoveDir = m_moveDir.down;
        }
        else if (movement.y >= 0.01f && Mathf.Abs(movement.x) < m_turnThresholdMoveY)
        {
            ChangeAnimationState(m_WALK_UP);
            m_LastMoveDir = m_moveDir.up;
        }
        else if (movement.x <= -0.01f)
        {
            ChangeAnimationState(m_WALK_LEFT);
            m_LastMoveDir = m_moveDir.left;
        }
        else if (movement.x >= 0.01f)
        {
            ChangeAnimationState(m_WALK_RIGHT);
            m_LastMoveDir = m_moveDir.right;
        }
        else
        {
            idleAnimation();
        }
    }
    #endregion
}
