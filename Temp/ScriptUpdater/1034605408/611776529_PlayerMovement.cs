using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;         // Speed at which the player moves
    private Rigidbody2D rb;              // Reference to the Rigidbody2D component

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Find the Rigidbody2D on this object
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");  // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");    // W/S or Up/Down

        Vector2 movement = new Vector2(moveX, moveY).normalized; // Prevents faster diagonal movement
        rb.linearVelocity = movement * moveSpeed;  // Apply velocity to the Rigidbody
    }
}
