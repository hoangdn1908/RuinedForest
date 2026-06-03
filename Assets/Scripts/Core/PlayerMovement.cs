using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Component")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;

    #region Run
    public void Run(float direction, float moveSpeed) 
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocityY);
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
            spriteRenderer.flipX = false;
        }
        else if(direction < 0f) 
        {
            spriteRenderer.flipY = true;
        }
    }
    #endregion
}
