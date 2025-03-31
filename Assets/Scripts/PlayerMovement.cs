using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;          // How fast the player moves
    private Rigidbody2D rb;               // The player's Rigidbody2D
    private Vector2 movement;             // Stores movement input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D from this GameObject
    }

    void Update()
    {
        // Get input from keyboard: A/D or Left/Right arrows
        float moveX = Input.GetAxisRaw("Horizontal");

        // Store the input in the movement variable
        movement = new Vector2(moveX, 0f);
    }

    void FixedUpdate()
    {
        // Move the player using physics
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
    }
}
