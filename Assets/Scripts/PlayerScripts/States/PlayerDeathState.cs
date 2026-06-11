using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public PlayerDeathState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        StopMovement();
        PlayDeathAnimation();
        playerController.StartCoroutine(DisableAfterDelay());
    }

    private void PlayDeathAnimation()
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Death);
    }

    private void StopMovement()
    {
        playerController.playerMovement.Stop();
    }

    private IEnumerator DisableAfterDelay() 
    {
        yield return new WaitForSeconds(0.35f);
        playerController.gameObject.SetActive(false);
    }
}
