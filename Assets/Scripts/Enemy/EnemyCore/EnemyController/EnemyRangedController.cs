using UnityEngine;

public class EnemyRangedController : EnemyController
{
    public override void IninializeStateMachine()
    {
        base.IninializeStateMachine();
        enemyAttackState = new EnemyRangedAttackState(this, enemyStateMachine);
    }
}
