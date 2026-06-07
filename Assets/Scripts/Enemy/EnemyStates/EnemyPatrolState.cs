using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private float patrolDirection = 1;
    private Transform transform { get { return enemyController.transform; } }
    public EnemyPatrolState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void Enter()
    {
        PlayPatrolAnimation();
    }

    public override void LogicUpdate()
    {
        if (CheckIdleState()) return;   
    }

    public override void PhysicUpdate()
    {
        Move();
    }

    private void PlayPatrolAnimation() 
    {
        enemyController.enemyAnimation.SetStateAnimation(EnemyAnimationStates.Patrol);
    }

    private void Move() 
    {
        enemyController.enemyMovement.Move(patrolDirection, enemyController.EnemyData.moveSpeed);
    }

    private void ChangeDirection() 
    {
        patrolDirection *= -1;
    }

    private bool IsReachedPatrolLimit()
    {
        float distanceFromStart = transform.position.x - enemyController.enemyMovement.startPos.x;
        float patrolDistance = enemyController.EnemyData.patrolDistance;

        if (patrolDirection > 0f) return distanceFromStart >= patrolDistance;
        return distanceFromStart <= 0f;
    }

    private bool CheckIdleState() 
    {
        if (IsReachedPatrolLimit()) 
        {
            ChangeDirection();
            enemyStateMachine.ChangeState(enemyController.enemyIdleState);
            return true;
        }
        return false;
    }

}
