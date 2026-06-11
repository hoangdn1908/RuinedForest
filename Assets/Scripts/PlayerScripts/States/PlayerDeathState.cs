using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerDeathState : PlayerBaseState
{
    public PlayerDeathState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        PlayDeathAnimation();
    }

    private void PlayDeathAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Death);
    }
}
