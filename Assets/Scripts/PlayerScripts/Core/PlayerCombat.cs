using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private Collider2D attackPoint;

    private void Awake()
    {
        EndAttack();
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
        if (attackPoint == null) return;
        attackPoint.enabled = false;
    }
}

