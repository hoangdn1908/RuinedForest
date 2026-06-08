using UnityEngine;

public class EnemyGroundDetection : MonoBehaviour
{
    [Header("Ground Checker")]
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private bool holdRigidbodyOnGround = true;

    private Rigidbody2D rb;
    private float defaultGravityScale;

    public bool IsGrounded { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale = rb.gravityScale;

        if (groundCheckPoint == null)
        {
            groundCheckPoint = transform;
        }
    }

    private void FixedUpdate()
    {
        CheckGround();
        HoldRigidbodyOnGround();
    }

    private void CheckGround()
    {
        IsGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    private void HoldRigidbodyOnGround()
    {
        if (!holdRigidbodyOnGround)
        {
            return;
        }

        if (IsGrounded)
        {
            rb.gravityScale = 0f;

            if (rb.linearVelocity.y < 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            }

            return;
        }

        rb.gravityScale = defaultGravityScale;
    }

    private void OnDrawGizmos()
    {
        if (groundCheckPoint == null)
        {
            return;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
    }
}
