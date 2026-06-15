using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    private EnemyController enemyController;
    private float damage;

    private void Awake()
    {
        enemyController = GetComponentInParent<EnemyController>();
        SetAttackDamage();
    }

    private void SetAttackDamage() 
    {
        damage = enemyController.EnemyData.attackDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerHealth playerHealth = collision.GetComponent<PlayerHealth>();
            if (playerHealth == null) return;
            playerHealth.TakeDamage(damage);
        }
    }
}
