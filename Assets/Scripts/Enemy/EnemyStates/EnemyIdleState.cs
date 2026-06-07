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

    private void CheckPatrolState() 
    {
        idleTimer -= Time.deltaTime;
        if (idleTimer <= 0)
        {
            enemyStateMachine.ChangeState(enemyController.enemyPatrolState);
        }
    }
}
