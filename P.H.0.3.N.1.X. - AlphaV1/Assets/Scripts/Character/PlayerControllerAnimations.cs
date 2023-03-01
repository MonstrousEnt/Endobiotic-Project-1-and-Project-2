using UnityEngine;

//Animation state machine based off of Lost Relic Games' tutorial: https://www.youtube.com/watch?v=nBkiSJ5z-hE

public class PlayerControllerAnimations : BaseControllerAnimations
{
    [Header("Components")]
    //[SerializeField] private Animator m_animator;

    [Header("Animation")]
    [SerializeField] private string m_currentAnimaton;
    [SerializeField] private string m_LastMoveDir = "D";
    [SerializeField] private float m_turnThresholdMoveY = 0.71f;

    //Animation States
    [Header("Animation States")]
    [SerializeField] private const string m_IDLE_DOWN = "Idle_Down";
    [SerializeField] private const string m_IDLE_UP = "Idle_Up";
    [SerializeField] private const string m_IDLE_LEFT = "Idle_Left";
    [SerializeField] private const string m_IDLE_RIGHT = "Idle_Right";

    [SerializeField] private const string m_WALK_DOWN = "Walk_Down";
    [SerializeField] private const string m_WALK_UP = "Walk_Up";
    [SerializeField] private const string m_WALK_LEFT = "Walk_Left";
    [SerializeField] private const string m_WALK_RIGHT = "Walk_Right";

    //Destroyer
    [SerializeField] private const string m_DEST_ATK_DOWN = "Atk_Down";
    [SerializeField] private const string m_DEST_ATK_UP = "Atk_Up";
    [SerializeField] private const string m_DEST_ATK_LEFT = "Atk_Left";
    [SerializeField] private const string m_DEST_ATK_RIGHT = "Atk_Right";

    //Magnetic
    [SerializeField] private const string m_MAGNET_PULL_DOWN = "Pull_Down";
    [SerializeField] private const string m_MAGNET_PULL_UP = "Pull_Up";
    [SerializeField] private const string m_MAGNET_PULL_LEFT = "Pull_Left";
    [SerializeField] private const string m_MAGNET_PULL_RIGHT = "Pull_Right";

    private float m_requiredTime;// variable to delay before next attack

    private void Start()
    {
        m_requiredTime = Time.time;
    }

    #region Animation Methods

    /// <summary>
    /// Checking for movement to animate based on input, 
    /// using turn threshold values to determine when the sprite will change direction on y axis
    /// </summary>
    /// <param name="movement"></param>
    public void MovementAnimation(Vector2 movement)
    {

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

    //Destroyer attack
    public void DestroyerAttack()
    {
        switch (m_LastMoveDir)
        {            
            case "U":
                ChangeAnimationState(m_DEST_ATK_UP);
                break;
            case "D":
                ChangeAnimationState(m_DEST_ATK_DOWN);
                break;
            case "L":
                ChangeAnimationState(m_DEST_ATK_LEFT);
                break;
            case "R":
                ChangeAnimationState(m_DEST_ATK_RIGHT);
                break;
        }
        m_requiredTime = Time.time + 0.25f;
    }

    //Magnet Pull
    public void MagnetPull()
    { 
        switch (m_LastMoveDir)
        {
            case "U":
                ChangeAnimationState(m_MAGNET_PULL_DOWN);
                break;
            case "D":
                ChangeAnimationState(m_MAGNET_PULL_DOWN);
                break;
            case "L":
                ChangeAnimationState(m_MAGNET_PULL_LEFT);
                break;
            case "R":
                ChangeAnimationState(m_MAGNET_PULL_RIGHT);
                break;
        }        
    }

    // mini animation manager
    /// <summary>
    /// Function to tell the animator to play the animation parameter we give it
    /// </summary>
    /// <param name="newAnimation"></param>
    void ChangeAnimationState(string newAnimation)
    {
        //check to see if the delay is in effect
        if (m_requiredTime > Time.time)
            return;
        //prevent the animation from interrupting itself
        if (m_currentAnimaton == newAnimation) return;
        //play the animation
        m_animator.Play(newAnimation);
        //reassign the current state
        m_currentAnimaton = newAnimation;
    }

    #endregion

}
