using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private Animator animator;

    [Header("Move")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 movement;

    [Header("Animation")]
    [SerializeField] private string currentAnimaton;
    [SerializeField] private string LastMoveDir = "D";
    [SerializeField] private float turnThresholdMoveY = 0.71f;

    //Animation States
    [Header("Animation States")]
    [SerializeField] private const string IDLE_DOWN = "Idle_Down";
    [SerializeField] private const string IDLE_UP = "Idle_Up";
    [SerializeField] private const string IDLE_LEFT = "Idle_Left";
    [SerializeField] private const string IDLE_RIGHT = "Idle_Right";

    [SerializeField] private const string WALK_DOWN = "Walk_Down";
    [SerializeField] private const string WALK_UP = "Walk_Up";
    [SerializeField] private const string WALK_LEFT = "Walk_Left";
    [SerializeField] private const string WALK_RIGHT = "Walk_Right";

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); //For move functions
    }

    void Update()
    {
        if (GameMangerRootMaster.instance.playerManager.canMove)
        {
            //Get the move directions (Up (y +1), Down (y -1), Left (x +1), and Right (x -1))
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }

    }

    private void FixedUpdate()
    {
        if (GameMangerRootMaster.instance.playerManager.canMove)
        {
            rigidBody2D.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

            Move();
        }
        else if (!GameMangerRootMaster.instance.playerManager.canMove)
        {
            rigidBody2D.velocity = Vector2.zero;
        }
    }

    private void Move()
    {   
        //if player can move:
        movementAnimation();
    }

        #region Animation Methods

        private void movementAnimation()
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

    // mini animation manager
    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    #endregion
}
