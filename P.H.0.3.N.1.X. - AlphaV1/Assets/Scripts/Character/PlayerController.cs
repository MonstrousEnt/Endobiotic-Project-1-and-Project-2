using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterInteractionController))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D m_rigidBody2D;
    [SerializeField] private PlayerControllerAnimations m_playerAnimation;

    private CharacterInteractionController m_characterInteractionController;

    [Header("Global Scriptable Object Variable")]
    [SerializeField] private BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerCanMove;

    [Header("Move")]
    [SerializeField] private float m_moveSpeed = 5;
    [SerializeField] private Vector2 m_movement;

    #region Unity Methods
    private void Start()
    {
        //Initialize Components
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
        if (!m_booleanFlagGlobalVariablePlayerCanMove.booleanFlag)
        {
            //Stop the movement
            m_rigidBody2D.velocity = Vector2.zero;
        }
        //Otherwise move the player
        else if (m_booleanFlagGlobalVariablePlayerCanMove.booleanFlag)
        {
            move();
        }
    }
    #endregion

    #region C# Methods
    /// <summary>
    /// The player inputs for moving and form action.
    /// </summary>
    private void inputs()
    {
        //If the player can move.
        if (m_booleanFlagGlobalVariablePlayerCanMove.booleanFlag)
        {
            //Get the move directions (Up (y +1), Down (y -1), Left (x +1), and Right (x -1)) for user input.
            m_movement.x = Input.GetAxis("Horizontal");
            m_movement.y = Input.GetAxis("Vertical");

            //When the user press e or X on Xbox. 
            if (Input.GetButton("FormAction"))
            {
                //Interact with the maze blocks.
                interact();
            }
        }
    }

    /// <summary>
    /// Move the player.
    /// </summary>
    private void move()
    {
        m_rigidBody2D.velocity = new Vector2(m_movement.x * m_moveSpeed, m_movement.y * m_moveSpeed);
        m_playerAnimation.CallMovementAnimation(m_movement);
    }

    /// <summary>
    /// Interact with the maze blocks
    /// </summary>
    private void interact()
    {
        m_characterInteractionController.Interact();
    }
    #endregion
}