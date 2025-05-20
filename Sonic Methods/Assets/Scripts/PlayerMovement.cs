using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float direction;
    public float speed = 5f;

    private Rigidbody2D rigid;
    private Animator animator;
    private PlayerJump jumpScript;
    private Collider2D myCollider;

    void Awake()
    {
        rigid = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>();
        jumpScript = GetComponentInChildren<PlayerJump>();
        myCollider = GetComponentInParent<Collider2D>();
    }

    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");
        bool isMoving = direction != 0;
        bool isGrounded = jumpScript != null && jumpScript.GetIsGrounded();
        animator.SetBool("IsWalking", isMoving && isGrounded);

        // Move player
        if (isMoving && rigid != null)
        {
            rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);
            transform.localScale = new Vector3(direction > 0 ? 1 : -1, 1, 1);
        }

        // Apply dynamic friction
        if (myCollider != null && jumpScript != null)
        {
            myCollider.sharedMaterial = isGrounded ? jumpScript.normalFriction : jumpScript.zeroFriction;
        }
    }
}
