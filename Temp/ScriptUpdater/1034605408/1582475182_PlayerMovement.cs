using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // PUBLIC VARIABLES (visible in the Inspector)

    [Header("Movement Settings")]
    public float moveSpeed = 5f;        // Controls how fast the player moves left/right
    public float jumpForce = 10f;       // Controls how high the player can jump

    [Header("Ground Check Settings")]
    public LayerMask groundLayer;       // Specifies which layers count as "ground"
    public Transform groundCheck;       // A small empty GameObject used to check if the player is standing on the ground
    public float groundCheckRadius = 0.2f;  // The size of the circle used to detect ground under the player

    // PRIVATE VARIABLES (used internally by the script)
    private bool isGrounded;            // Tracks whether the player is currently on the ground
    private Rigidbody2D rb;             // The Rigidbody2D component attached to the player

    void Start()
    {
        // Get and store a reference to the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get horizontal input from player (A/D or Left/Right arrow keys)
        float moveX = Input.GetAxisRaw("Horizontal");

        // Note: Vertical input is unused for movement but included for completeness
        float moveY = Input.GetAxisRaw("Vertical");

        // Create a movement vector and normalize it to prevent faster diagonal movement
        Vector2 movement = new Vector2(moveX, moveY).normalized;

        // Apply horizontal movement using linear velocity
        // We keep the vertical velocity unchanged so jumping/falling remains unaffected
        rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);

        // Jump when the Space key is pressed and the player is grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply vertical velocity to perform the jump
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Check if the player is touching the ground
        // Physics2D.OverlapCircle returns true if a collider overlaps with the defined circle area
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    // OPTIONAL: You can use Unity's Gizmos to visually display the ground check radius in the Scene view
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
