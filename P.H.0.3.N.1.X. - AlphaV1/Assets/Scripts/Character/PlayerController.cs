/* Project Name: Endobiotic - Project 2: Preparation for Galaxy Edition
 * Team Name: Monstrous Entertainment - Vex Team
 * Authors: Daniel Cox, James Dalziel,
 * Created Date: February 12, 2023
 * Last Updated: Match 29, 2023
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
    [Header("Components (Reference by Unity")]
    [SerializeField] private PlayerControllerAnimations m_playerAnimation;

    [Header("Global Scriptable Object Variable")]
    [SerializeField] private BooleanFlagGlobalVariableScriptableObject m_booleanFlagGlobalVariablePlayerCanMove;

    [Header("Move")]
    [SerializeField] private float m_moveSpeed = 5;
    [SerializeField] private Vector2 m_movement;

    //Components (Initializes in Awake)
    private Rigidbody2D m_rigidBody2D;
    private CharacterInteractionController m_characterInteractionController;
    #endregion

    #region Unity Methods
    private void Awake()
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
        if (!m_booleanFlagGlobalVariablePlayerCanMove.booleanFlag)
        {
            m_rigidBody2D.velocity = Vector2.zero;
        }
        else if (m_booleanFlagGlobalVariablePlayerCanMove.booleanFlag)
        {
            move();
        }
    }
    #endregion

    #region Player Controller Methods
    private void inputs()
    {
       
        if (m_booleanFlagGlobalVariablePlayerCanMove.booleanFlag)
        {
            //Move
            m_movement.x = Input.GetAxis("Horizontal");
            m_movement.y = Input.GetAxis("Vertical");

            //Form Action
            if (Input.GetButton("FormAction"))
            {
                interact();
            }
        }
    }

    private void move()
    {
        m_rigidBody2D.velocity = new Vector2(m_movement.x * m_moveSpeed, m_movement.y * m_moveSpeed);
        m_playerAnimation.CallMovementAnimation(m_movement);
    }

    private void interact()
    {
        m_characterInteractionController.Interact();
    }
    #endregion
}