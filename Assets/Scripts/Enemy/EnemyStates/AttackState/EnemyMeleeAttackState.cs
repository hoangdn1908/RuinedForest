using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    private float attackTimer;
    public EnemyMeleeAttackState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
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
        else enemyStateMachine.ChangeState(enemyController.enemyChaseState);
    }

    private void AttackPlayer() 
    {
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            DecideNextState();
        }
    }
}
