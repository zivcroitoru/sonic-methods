using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float direction;
    public float speed = 5f;

    private Rigidbody2D rigid;
    private Animator animator;
    private PlayerJump jumpScript;

    void Awake()
    {
        rigid = GetComponentInParent<Rigidbody2D>();
        animator = GetComponentInParent<Animator>(); // ⬅️ key fix
        jumpScript = GetComponentInChildren<PlayerJump>();

        if (animator == null)
            Debug.LogWarning("Animator not found in parent! Assign manually.");
    }


    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");

        bool isMoving = direction != 0;
        bool isGrounded = jumpScript != null && jumpScript.GetIsGrounded();

        animator.SetBool("IsWalking", isMoving && isGrounded);

        if (isMoving && rigid != null)
        {
            rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);
            transform.localScale = new Vector3(direction > 0 ? 1 : -1, 1, 1);
        }
    }
}