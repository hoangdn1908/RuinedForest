using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    private EnemyController enemyController;

    private void Awake()
    {
        enemyController = GetComponent<EnemyController>();
        EndAttack();
    }

    private void Update()
    {
        FlipAttackPoint();
    }
    public void StartAttack() 
    {
        attackPoint.gameObject.SetActive(true);
    }

    public void EndAttack() 
    {
        attackPoint.gameObject.SetActive(false);
    }

    private void FlipAttackPoint() 
    {
        attackPoint.localPosition = new Vector3(Mathf.Abs(attackPoint.localPosition.x) * enemyController.enemyMovement.FacingDirection, attackPoint.localPosition.y, 0f);
    }
}
