using UnityEngine;

//Animation state machine based off of Lost Relic Games' tutorial: https://www.youtube.com/watch?v=nBkiSJ5z-hE

public class EnemyControllerAnimations : BaseControllerAnimations
{
    private string currentAnimaton;
    private string LastMoveDir = "D";
    private float turnThresholdMoveY = 0.71f;

    private const string IDLE_DOWN = "Idle_Down";
    private const string IDLE_UP = "Idle_Up";
    private const string IDLE_LEFT = "Idle_Left";
    private const string IDLE_RIGHT = "Idle_Right";

    private const string WALK_DOWN = "Walk_Down";
    private const string WALK_UP = "Walk_Up";
    private const string WALK_LEFT = "Walk_Left";
    private const string WALK_RIGHT = "Walk_Right";

    private Vector3 previousPosition;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void Update()
    {
        //enemy based movement detection
        Vector3 deltaMovement = transform.position - previousPosition;
        Vector2 changeInPosition = new Vector2(deltaMovement.x, deltaMovement.y);
        MovementAnimation(changeInPosition);
        previousPosition = transform.position;
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

        if (movement.y <= -0.01f && Mathf.Abs(movement.x) < turnThresholdMoveY)
        {
            ChangeAnimationState(WALK_DOWN);
            LastMoveDir = "D";
        }
        else if (movement.y >= 0.01f && Mathf.Abs(movement.x) < turnThresholdMoveY)
        {
            ChangeAnimationState(WALK_UP);
            LastMoveDir = "U";
        }
        else if (movement.x <= -0.01f)
        {
            ChangeAnimationState(WALK_LEFT);
            LastMoveDir = "L";
        }
        else if (movement.x >= 0.01f)
        {
            ChangeAnimationState(WALK_RIGHT);
            LastMoveDir = "R";
        }

        //Idle
        else
        {
            if (LastMoveDir == "D")
                ChangeAnimationState(IDLE_DOWN);
            else if (LastMoveDir == "U")
                ChangeAnimationState(IDLE_UP);
            else if (LastMoveDir == "L")
                ChangeAnimationState(IDLE_LEFT);
            else if (LastMoveDir == "R")
                ChangeAnimationState(IDLE_RIGHT);
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
        if (currentAnimaton == newAnimation) return;
        //play the animation
        m_animator.Play(newAnimation);
        //reassign the current state
        currentAnimaton = newAnimation;
    }
}
