using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int FacingDirection { get; private set; } = 1;
    public Vector2 startPos {  get; private set; }

    public void SetStartPos(Vector2 startPos) 
    {
        this.startPos = startPos;
    }

    public void Move(float direction, float moveSpeed) 
    {
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);
        FlipEnemy(direction);
    }

    public void Stop() 
    {
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    private void FlipEnemy(float direction) 
    {
        if (direction > 0f)
        {
            FacingDirection = 1;
            spriteRenderer.flipX = false;
        }
        else if (direction < 0f) 
        {
            FacingDirection = -1;
            spriteRenderer.flipX = true;
        }
    }
}
