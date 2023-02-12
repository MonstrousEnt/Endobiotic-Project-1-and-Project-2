using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Rigidbody2D rb2D;

    [Header("Move")]
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>(); //For move functions
    }

    // Update is called once per frame
    void Update()
    {
        //Get the move directions (Up (y +1), Down (y -1), Left (x +1), and Right (x -1))
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }
}
