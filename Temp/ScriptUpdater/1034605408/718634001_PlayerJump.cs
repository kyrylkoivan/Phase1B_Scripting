using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpForce = 7f;
    private Rigidbody2D rb;

    public Transform groundCheck; // The empty object under the player's feet
    public float groundCheckRadius = 0.2f; // How big the check circle is
    public LayerMask whatIsGround; // The layer the ground is on
    private bool isGrounded; // Are we currently touching ground?

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

}
