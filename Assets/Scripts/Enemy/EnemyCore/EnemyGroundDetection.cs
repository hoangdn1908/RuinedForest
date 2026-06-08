using UnityEngine;

public class EnemyGroundDetection : MonoBehaviour
{
    [SerializeField] private Transform groundCheckpoint;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayerMask;
    private bool holdRigidbodyOnGround = true;
    private Rigidbody2D rb;
    private float defaultGravityScale;
    public bool IsGround {  get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        defaultGravityScale  = rb.gravityScale;
        if (groundCheckpoint == null) groundCheckpoint = transform;
    }

    private void FixedUpdate()
    {
        CheckGround();
        HoldRigidbodyOnGround();
    }

    private void CheckGround() 
    {
        IsGround = Physics2D.OverlapCircle(groundCheckpoint.position, groundCheckRadius, groundLayerMask);
    }

    private void HoldRigidbodyOnGround() 
    {
        if (!holdRigidbodyOnGround) return;
        if (IsGround) 
        {
            rb.gravityScale = 0;
            if (rb.linearVelocityY < 0f)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0f);
            }
            else rb.gravityScale = defaultGravityScale;
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if (groundCheckpoint == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckpoint.position, groundCheckRadius);
    }
#endif
}
