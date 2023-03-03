using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterInteractionController))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D m_rigidBody2D;
    [SerializeField] private PlayerControllerAnimations m_playerAnimation;
    private CharacterInteractionController m_characterInteractionController;

    [Header("Move")]
    [SerializeField] private float m_moveSpeed = 5;
    [SerializeField] private Vector2 m_movement;

    private void Start()
    {
        m_rigidBody2D = GetComponent<Rigidbody2D>(); 
        m_characterInteractionController = GetComponent<CharacterInteractionController>();
    }

    private void Update()
    {
        inputs();
    }

    private void FixedUpdate()
    {
        //If the player can't move
        if (!GameMangerRootMaster.instance.playerManager.CanMove())
        {
            //Stop the movement
            m_rigidBody2D.velocity = Vector2.zero;
        }
        //Otherwise move the player
        else if (GameMangerRootMaster.instance.playerManager.CanMove())
        {
            Move();
        }
    }

    /// <summary>
    /// The player inputs for moving and form action.
    /// </summary>
    private void inputs()
    {
        //If the player can move.
        if (GameMangerRootMaster.instance.playerManager.CanMove())
        {
            //Get the move directions (Up (y +1), Down (y -1), Left (x +1), and Right (x -1)) for user input.
            m_movement.x = Input.GetAxis("Horizontal");
            m_movement.y = Input.GetAxis("Vertical");

            //When the user press e or X on Xbox. 
            if (Input.GetButton("FormAction"))
            {
                //Interact with the maze blocks.
                Interact();
            }
        }
    }

    /// <summary>
    /// Move the player.
    /// </summary>
    private void Move()
    {
        m_rigidBody2D.velocity = new Vector2(m_movement.x * m_moveSpeed, m_movement.y * m_moveSpeed);
        m_playerAnimation.MovementAnimation(m_movement);
    }

    /// <summary>
    /// Interact with the maze blocks
    /// </summary>
    private void Interact()
    {
        m_characterInteractionController.Interact();
    }       
}