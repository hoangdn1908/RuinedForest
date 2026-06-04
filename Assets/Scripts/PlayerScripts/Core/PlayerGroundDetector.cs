using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] private Transform groundCheckpoint;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    public bool IsGround() 
    {
        return Physics2D.OverlapCircle(groundCheckpoint.position, groundCheckRadius, groundLayer);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheckpoint.position, groundCheckRadius);
    }
}
