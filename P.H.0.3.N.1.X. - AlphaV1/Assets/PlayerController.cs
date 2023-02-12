using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rigidBody2D;

    [Header("Move")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 movement;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>(); //For move functions
    }

    void Update()
    {
        //Get the move directions (Up (y +1), Down (y -1), Left (x +1), and Right (x -1))
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(movement.x * moveSpeed, movement.y * moveSpeed);
    }
}
