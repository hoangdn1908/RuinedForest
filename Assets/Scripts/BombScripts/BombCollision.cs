using UnityEngine;

public class BombCollision : MonoBehaviour
{
    private BombController bombController;
    private EnemyController enemyController;

    private void Awake()
    {
        bombController = GetComponent<BombController>();
        enemyController = GetComponentInParent<EnemyController>();
    }
    #region Collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!bombController.isExploding && other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponentInParent<PlayerHealth>();
            if (playerHealth == null) return;
            bombController.Explosion();
            playerHealth.TakeDamage(enemyController.EnemyData.attackDamage); 
        }
        else if (!bombController.isExploding && other.CompareTag("Ground")) 
        {
            bombController.Explosion();
        }
    }
    #endregion
}
