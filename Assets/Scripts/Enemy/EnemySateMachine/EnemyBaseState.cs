using UnityEngine;

public class EnemyBaseState 
{
    protected EnemyController enemyController;
    protected EnemyStateMachine enemyStateMachine;

    public EnemyBaseState(EnemyController enemyController, EnemyStateMachine enemyStateMachine)
    {
        this.enemyController = enemyController;
        this.enemyStateMachine = enemyStateMachine;
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void LogicUpdate() { }
    public virtual void PhysicUpdate() { }
}
