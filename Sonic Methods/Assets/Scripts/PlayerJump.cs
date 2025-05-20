using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private LayerMask groundLayer;

    [Header("References (set in Inspector or auto-assigned)")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private float playerHalfHeight;

    private void Start()
    {
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }

    private void Update()
    {
        bool grounded = GetIsGrounded();
        animator.SetBool("IsInAir", !grounded);

        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jumping!");
            Jump();
        }
    }

    public bool GetIsGrounded()
    {
        Vector2 origin = spriteRenderer.transform.position;
        float rayLength = playerHalfHeight + 0.1f;
        return Physics2D.Raycast(origin, Vector2.down, rayLength, groundLayer);
    }

    private void Jump()
    {
        animator.SetBool("IsInAir", true);
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}