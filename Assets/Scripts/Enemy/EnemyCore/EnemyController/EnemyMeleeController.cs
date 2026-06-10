using UnityEngine;

public class EnemyMeleeController : EnemyController
{
    public override void IninializeStateMachine()
    {
        base.IninializeStateMachine();
        enemyAttackState = new EnemyMeleeAttackState(this,  enemyStateMachine);
    }
}
