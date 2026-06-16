using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private PlayerController playerController;
    private float damage;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        SetDamage();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.GetComponentInParent<EnemyHealth>();
            if (enemyHealth == null) return;
            enemyHealth.TakeDamage(damage);
        }
    }

    private void SetDamage() 
    {
        damage = playerController.PlayerData.attackDamage;
    }
}
