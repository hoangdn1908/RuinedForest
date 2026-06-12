using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private float damage = 10f;

    private void Awake()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) 
        {
            EnemyHealth enemyHealth = collision.GetComponentInParent<EnemyHealth>();
            if (enemyHealth == null) return;
            enemyHealth.TakeDamage(damage);
            Debug.Log(damage);
        }
    }
}
