using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 7f; // Force applied when jumping

    [Header("Ground Check Settings")]
    public Transform groundCheck;          // Empty GameObject placed beneath the player to check for ground
    public float groundCheckRadius = 0.2f; // Radius of the ground detection circle
    public LayerMask whatIsGround;         // Layer(s) that count as ground

    private Rigidbody2D rb;       // Reference to the player's Rigidbody2D component
    private bool isGrounded = false; // True if the player is touching the ground

    // Called when the script starts
    void Start()
    {
        // Get and store the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    // Called every frame (for checking input)
    void Update()
    {
        // If the player is grounded and the spacebar is pressed...
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // ...apply upward velocity to make the player jump
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Called at fixed intervals (better for physics updates)
    void FixedUpdate()
    {
        // Check if the player is touching the ground using a circle cast
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Optional: Draw ground check gizmo in the editor for debugging
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
