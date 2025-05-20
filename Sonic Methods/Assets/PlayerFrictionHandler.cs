using UnityEngine;

public class PlayerFrictionHandler : MonoBehaviour
{
    [Header("Physics Materials")]
    [SerializeField] private PhysicsMaterial2D zeroFriction;
    [SerializeField] private PhysicsMaterial2D normalFriction;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    private Collider2D myCollider;

    void Awake()
    {
        myCollider = GetComponent<Collider2D>();
    }

    void FixedUpdate()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        myCollider.sharedMaterial = isGrounded ? normalFriction : zeroFriction;
    }
}
