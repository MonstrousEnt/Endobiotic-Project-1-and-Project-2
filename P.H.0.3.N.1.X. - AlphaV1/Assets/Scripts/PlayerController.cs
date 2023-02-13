using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private Animator animator;

    [Header("Free Movement")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 movement;

    [Header("Gird Base Movement")]
    [SerializeField] private bool isMoving;
    [SerializeField] private Vector2 origPos;
    [SerializeField] private Vector2 targetPos;
    [SerializeField] private float timeToMove = 0.2f; //This time is in seconds


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
        inputsGirdBasedMovement();
    }

    private void FixedUpdate()
    {
       
    }

    private void inputsFreeMovement()
    {
        //Get the move directions (Up (y +1), Down (y -1), Left (x +1), and Right (x -1))
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void freeMovement()
    {
        rigidBody2D.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }

    private void inputsGirdBasedMovement()
    {
        if (Input.GetKey(KeyCode.W) && !isMoving)
        {
            Move(Vector2.up);
        }

        if (Input.GetKey(KeyCode.A) && !isMoving)
        {
            Move(Vector2.left);
        }

        if (Input.GetKey(KeyCode.S) && !isMoving)
        {
            Move(Vector2.down);
        }

        if (Input.GetKey(KeyCode.D) && !isMoving)
        {
            Move(Vector2.right);
        }
    }

    private IEnumerator MovePlayerGridBased(Vector2 direction)
    {
        isMoving = true;

        float elapsedTime = 0;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector2.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    private void Move(Vector2 direction)
    {
        StopCoroutine(MovePlayerGridBased(direction));
        StartCoroutine(MovePlayerGridBased(direction));

        //freeMovement();

        //if player can move:
        movementAnimation(direction);
    }

        #region Animation Methods

        private void movementAnimation(Vector2 direction)
    {
        
        if (direction.y <= -0.01f && Mathf.Abs(movement.x) < turnThresholdMoveY)
        {
            ChangeAnimationState(WALK_DOWN);
            LastMoveDir = "D";
        }
        else if (direction.y >= 0.01f && Mathf.Abs(movement.x) < turnThresholdMoveY)
        {
            ChangeAnimationState(WALK_UP);
            LastMoveDir = "U";
        }
        else if (direction.x <= -0.01f)
        {
            ChangeAnimationState(WALK_LEFT);
            LastMoveDir = "L";
        }
        else if (direction.x >= 0.01f)
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
