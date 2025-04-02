using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;       // Reference to the Animator

    [Header("Movement Settings")]
    public float moveSpeed = 5f; // Controls how fast the player moves left/right

    private Rigidbody2D rb;      // Reference to the Rigidbody2D component

    void Start()
    {
        // Get and store a reference to the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {

        // Get horizontal input from the player (A/D or Left/Right arrow keys)
        float moveX = Input.GetAxisRaw("Horizontal");

        // Calculate horizontal velocity while preserving vertical motion
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);


        float horizontalSpeed = Mathf.Abs(rb.linearVelocity.x);
        anim.SetFloat("Speed", horizontalSpeed);
    }


}
