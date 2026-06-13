using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int FacingDirection { get; private set; } = 1;

    #region Run
    public void Run(float direction, float moveSpeed) 
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        FlipPlayer(direction);
    }

    public void Stop() 
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocityY);
    }

    private void FlipPlayer(float direction) 
    {
        if (direction > 0f) 
        {
            FacingDirection = 1;
            spriteRenderer.flipX = false;
        }
        else if(direction < 0f) 
        {
            FacingDirection = -1;
            spriteRenderer.flipX = true;
        }
    }
    #endregion

    #region Jump
    public void Jump(float jumpForce) 
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public float GetVeticalVelocity() 
    {
        return rb.linearVelocityY;
    }
    #endregion
}
