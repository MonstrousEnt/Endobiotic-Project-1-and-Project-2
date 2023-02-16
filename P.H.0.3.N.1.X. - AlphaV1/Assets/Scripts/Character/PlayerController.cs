using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterInteractionController))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidBody2D;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerControllerAnimations playerAnimation;
    private CharacterInteractionController characterInteractionController;

    [Header("Move")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 movement;  

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); //For move functions
        characterInteractionController = GetComponent<CharacterInteractionController>();
    }

    void Update()
    {
        if (GameMangerRootMaster.instance.playerManager.CanMove())
        {
            //Get the move directions (Up (y +1), Down (y -1), Left (x +1), and Right (x -1))
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Interact();
        }

    }

    private void FixedUpdate()
    {
        if (GameMangerRootMaster.instance.playerManager.CanMove())
        {
            rigidBody2D.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);

            Move();
        }
        else if (!GameMangerRootMaster.instance.playerManager.CanMove())
        {
            rigidBody2D.velocity = Vector2.zero;
        }
    }

    private void Move()
    {
        //if player can move:
        playerAnimation.MovementAnimation(movement);
    }

    private void Interact()
    {
        characterInteractionController.Interact();
    }

        
}
