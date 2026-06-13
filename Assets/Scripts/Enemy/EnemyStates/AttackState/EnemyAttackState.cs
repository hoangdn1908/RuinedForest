using UnityEngine;

public class EnemyAttackState : EnemyBaseState
{
    private float attackTimer;
   public EnemyAttackState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void Enter()
    {
        StopMovement();
        PlayAttackAnimation();
        SetAttackTimer();
    }

    public override void LogicUpdate()
    {
        CheckDeathState();
        AttackPlayer();
    }

    private void PlayAttackAnimation()
    {
        enemyController.enemyAnimation.SetStateAnimation(EnemyAnimationStates.Attack);
    }

    private void StopMovement()
    {
        enemyController.enemyMovement.Stop();
    }
    private void SetAttackTimer()
    {
        attackTimer = enemyController.EnemyData.attackDuration;
    }

    private void DecideNextState()
    {
        if (enemyController.enemyDetection.CanAttackPlayer(enemyController.EnemyData.attackRange)) SetAttackTimer();
        else if (!enemyController.enemyDetection.CanAttackPlayer(enemyController.EnemyData.attackRange) && enemyController.EnemyData.canChase)
            enemyStateMachine.ChangeState(enemyController.enemyChaseState);
        else enemyStateMachine.ChangeState(enemyController.enemyIdleState);
    }

    private void AttackPlayer()
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            DecideNextState();
        }
    }

    private bool CheckDeathState()
    {
        if (!enemyController.enemyHealth.IsAlive())
        {
            enemyStateMachine.ChangeState(enemyController.enemyDeathState);
            return true;
        }
        return false;
    }
}
