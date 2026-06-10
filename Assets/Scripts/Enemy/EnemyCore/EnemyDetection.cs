using Unity.VisualScripting;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayerMask;
    public Transform CurrentTarget { get; private set; }
    public bool CanDetectPlayer(float range)
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, range, playerLayerMask);
        CurrentTarget = player?.transform;
        return CurrentTarget != null;
    }

    public bool CanAttackPlayer(float range) 
    {
        Collider2D player = Physics2D.OverlapCircle(transform.position, range, playerLayerMask);
        CurrentTarget = player?.transform;
        return CurrentTarget != null;
    }
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        EnemyController enemyController = GetComponent<EnemyController>();
        if (enemyController == null || enemyController.EnemyData == null)
        {
            return;
        }

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, enemyController.EnemyData.detectionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyController.EnemyData.attackRange);
    }
#endif
}
