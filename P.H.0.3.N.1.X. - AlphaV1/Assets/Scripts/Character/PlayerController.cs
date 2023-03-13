/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, James Dalziel,
 * Created Date: February 12, 2023
 * Last Updated: Match 12, 2023
 * Description: This is the class for player controls.
 * Notes:
 * Resources: 
 */

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterInteractionController))]
public class PlayerController : MonoBehaviour
{
    #region Class Variables 
    [Header("Components")]
    [SerializeField] private PlayerControllerAnimations m_playerAnimation;
    private Rigidbody2D m_rigidBody2D;
    private CharacterInteractionController m_characterInteractionController;

    [Header("Global Scriptable Object Variable")]
    [SerializeField] private BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerCanMove;

    [Header("Move")]
    [SerializeField] private float m_moveSpeed = 5;
    [SerializeField] private Vector2 m_movement;
    #endregion

    #region Unity Methods
    private void Awake()
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