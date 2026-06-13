using UnityEngine;

public class EnemyRangedAttackState : EnemyAttackState
{
    public EnemyRangedAttackState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        FaceToTarget();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        FaceToTarget();
    }

    private void FaceToTarget() 
    {
        if (enemyController.enemyDetection.CurrentTarget == null) return;
        enemyController.enemyMovement.FaceTarget(enemyController.enemyDetection.CurrentTarget.position.x);
    }
}
