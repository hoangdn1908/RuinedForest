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
        Debug.Log("START ATTACK EVENT");

        if (attackPoint == null)
        {
            Debug.LogWarning("[PlayerCombat] attackPoint chưa được assign!");
            return;
        }

        attackPoint.enabled = true;
    }

    public void EndAttack()
    {
        Debug.Log("END ATTACK EVENT");

        if (attackPoint == null) return;

        attackPoint.enabled = false;
    }


    public void ResetAttack() 
    {
        if (attackPoint == null) return;
        attackPoint.enabled = false;
    }
}

