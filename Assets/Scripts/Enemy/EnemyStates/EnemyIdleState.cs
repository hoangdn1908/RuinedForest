using UnityEngine;

public class EnemyIdleState : EnemyBaseState
{
    private float idleTimer;
    public EnemyIdleState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void Enter()
    {
        StopMovement();
        SetIdleTimer();
        PlayIdleAnimation();
    }

    public override void LogicUpdate()
    {

        if(CheckDeathState()) return;
        if(CheckAttackState()) return;
        if(CheckChaseState()) return;
        CheckPatrolState();
    }

    private void StopMovement() 
    {
        enemyController.enemyMovement.Stop();
    }

    private void PlayIdleAnimation() 
    {
        enemyController.enemyAnimation.SetStateAnimation(EnemyAnimationStates.Idle);
    }

    private void SetIdleTimer() 
    {
        idleTimer = enemyController.EnemyData.idleDuration;
    }

    #region Check State 
    private void CheckPatrolState() 
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0 && enemyController.EnemyData.canPatrol)
        {
            enemyStateMachine.ChangeState(enemyController.enemyPatrolState);
        }
    }

    private bool CheckChaseState() 
    {
        if (enemyController.enemyDetection.CanDetectPlayer(enemyController.EnemyData.detectionRange) && enemyController.EnemyData.canChase) 
        {
            enemyStateMachine.ChangeState(enemyController.enemyChaseState);
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

    private bool CheckAttackState()
    {
        if (enemyController.enemyDetection.CanAttackPlayer(enemyController.EnemyData.attackRange))
        {
            enemyStateMachine.ChangeState(enemyController.enemyAttackState);
            return true;
        }
        return false;
    }
    #endregion
}
