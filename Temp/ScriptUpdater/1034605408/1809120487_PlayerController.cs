using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Movement Settings")]
    public float moveSpeed = 5f;

    [Header("Jump Settings")]
    public float jumpForce = 7f;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Debug.Log(rb.linearVelocity);         // ✅ Will compile and log
        Debug.Log(rb.linearVelocity);   // ❌ Will not compile in default Unity 2D
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // ----- Horizontal Movement -----
        float moveX = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // ----- Flip Sprite if Needed -----
        if (moveX != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(moveX);
            transform.localScale = scale;
        }

        // ----- Jump Input -----
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        // ----- Animation Parameters -----
        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        anim.SetFloat("Speed", horizontalSpeed);
    }

    void FixedUpdate()
    {
        // ----- Ground Detection -----
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        // ----- Update Animator -----
        anim.SetBool("IsJumping", !isGrounded);
    }

    // Debug gizmo to show the ground check area
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
