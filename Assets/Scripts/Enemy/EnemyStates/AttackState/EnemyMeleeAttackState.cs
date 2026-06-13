using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    public EnemyMeleeAttackState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void Exit()
    {
        enemyController.enemyCombat.EndAttack();
    }
}
