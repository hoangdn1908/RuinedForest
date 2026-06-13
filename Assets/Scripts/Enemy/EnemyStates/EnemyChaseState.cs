using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    public EnemyChaseState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void Enter()
    {
        PlayChaseAnimation();
    }

    public override void LogicUpdate()
    {
        if (CheckDeathState()) return;
        if (CheckAttackState()) return;
        if (CheckPatrolState()) return;
    }

    public override void PhysicUpdate()
    {
        ChasePlayer();
    }

    private void PlayChaseAnimation() 
    {
        enemyController.enemyAnimation.SetStateAnimation(EnemyAnimationStates.Patrol);
    }

    private float GetMoveDirection() 
    {
        if (enemyController.enemyDetection.CurrentTarget == null) return 1;
        return Mathf.Sign(enemyController.enemyDetection.CurrentTarget.position.x - enemyController.transform.position.x);
    }

    private void ChasePlayer() 
    {
        enemyController.enemyMovement.Move(GetMoveDirection(), enemyController.EnemyData.moveSpeed * 1.2f);
    }

    #region Check State
    private bool CheckPatrolState() 
    {
        if (!enemyController.enemyDetection.CanDetectPlayer(enemyController.EnemyData.detectionRange))
        {
            enemyStateMachine.ChangeState(enemyController.enemyPatrolState);
            return true;    
        }
        return false;
    }

    private bool CheckAttackState() 
    {
        if (enemyController.enemyDetection.CanAttackPlayer(enemyController.EnemyData.attackRange))
        {
            enemyStateMachine.ChangeState(enemyController.enemyAttackState);
            return true;
        }
        return false;
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
    #endregion
}
