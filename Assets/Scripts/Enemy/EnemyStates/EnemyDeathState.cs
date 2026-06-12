using System.Collections;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    public EnemyDeathState(EnemyController enemyController, EnemyStateMachine enemyStateMachine) : base(enemyController, enemyStateMachine)
    {

    }

    public override void Enter()
    {
        StopMovement();
        PlayDeathAnimation();
        enemyController.StartCoroutine(DisableAfterDelay());
    }

    private void StopMovement() 
    {
        enemyController.enemyMovement.Stop();
    }

    private void PlayDeathAnimation() 
    {
        enemyController.enemyAnimation.SetStateAnimation(EnemyAnimationStates.Death);
    }

    private IEnumerator DisableAfterDelay() 
    {
        yield return new WaitForSeconds(0.21f);
        enemyController.gameObject.SetActive(false);
    }
}
