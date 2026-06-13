using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Collider2D attackPoint;
    [SerializeField] private Transform attackTransform;
    private PlayerController playerController;

    private void Awake()
    {
        ResetAttack();
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        FlipAttackPoint();
    }

    public void StartAttack()
    {
        attackPoint.enabled = true;
    }

    public void EndAttack()
    { 
        attackPoint.enabled = false;
    }

    public void ResetAttack() 
    {
        attackPoint.enabled = false;
    }

    private void FlipAttackPoint() 
    {
        attackTransform.localPosition = new Vector3(Mathf.Abs(attackTransform.localPosition.x) * playerController.playerMovement.FacingDirection, attackTransform.localPosition.y, 0f);
    }
}

