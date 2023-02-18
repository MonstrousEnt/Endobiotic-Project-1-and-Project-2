using UnityEngine;

public class PlayerControllerAnimations : BaseControllerAnimations
{
    [Header("Components")]
    //[SerializeField] private Animator m_animator;

    [Header("Animation")]
    [SerializeField] private string currentAnimaton;
    [SerializeField] private string LastMoveDir = "D";
    [SerializeField] private float turnThresholdMoveY = 0.71f;

    //Animation States
    [Header("Animation States")]
    [SerializeField] public const string IDLE_DOWN = "Idle_Down";
    [SerializeField] private const string IDLE_UP = "Idle_Up";
    [SerializeField] private const string IDLE_LEFT = "Idle_Left";
    [SerializeField] private const string IDLE_RIGHT = "Idle_Right";

    [SerializeField] private const string WALK_DOWN = "Walk_Down";
    [SerializeField] private const string WALK_UP = "Walk_Up";
    [SerializeField] private const string WALK_LEFT = "Walk_Left";
    [SerializeField] private const string WALK_RIGHT = "Walk_Right";

    //Destroyer
    [SerializeField] private const string DEST_ATK_DOWN = "Atk_Down";
    [SerializeField] private const string DEST_ATK_UP = "Atk_Up";
    [SerializeField] private const string DEST_ATK_LEFT = "Atk_Left";
    [SerializeField] private const string DEST_ATK_RIGHT = "Atk_Right";

    //Magnetic
    [SerializeField] private const string MAGNET_PULL_DOWN = "Pull_Down";
    [SerializeField] private const string MAGNET_PULL_UP = "Pull_Up";
    [SerializeField] private const string MAGNET_PULL_LEFT = "Pull_Left";
    [SerializeField] private const string MAGNET_PULL_RIGHT = "Pull_Right";

    private float requiredTime;

    private void Start()
    {
        requiredTime = Time.time;
    }

    #region Animation Methods

    public void MovementAnimation(Vector2 movement)
    {

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

    //Destroyer attack
    public void DestroyerAttack()
    {
        switch (LastMoveDir)
        {            
            case "U":
                ChangeAnimationState(DEST_ATK_UP);
                break;
            case "D":
                ChangeAnimationState(DEST_ATK_DOWN);
                break;
            case "L":
                ChangeAnimationState(DEST_ATK_LEFT);
                break;
            case "R":
                ChangeAnimationState(DEST_ATK_RIGHT);
                break;
        }
        requiredTime = Time.time + 0.25f;
    }

    //Magnet Pull
    public void MagnetPull()
    { 
        switch (LastMoveDir)
        {
            case "U":
                ChangeAnimationState(MAGNET_PULL_DOWN);
                break;
            case "D":
                ChangeAnimationState(MAGNET_PULL_DOWN);
                break;
            case "L":
                ChangeAnimationState(MAGNET_PULL_LEFT);
                break;
            case "R":
                ChangeAnimationState(MAGNET_PULL_RIGHT);
                break;
        }        
    }

    // mini animation manager
    void ChangeAnimationState(string newAnimation)
    {
        if (requiredTime > Time.time)
            return;

        if (currentAnimaton == newAnimation) return;

        m_animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    #endregion

}
