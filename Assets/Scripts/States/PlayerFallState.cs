using Unity.VisualScripting;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        PlayFallAnimation();
    }

    public override void LogicUpdate()
    {
        ChangeToRightState();
    }

    public override void PhysicUpdate()
    {
        MoveInAir();
    }

    private void PlayFallAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Fall);
    }

    private void MoveInAir()
    {
        playerController.playerMovement.Run(playerController.playerInput.MoveInput, playerController.PlayerData.runSpeed);
    }

    private void ChangeToRightState() 
    {
        if (playerController.playerGroundDetector.IsGround()) 
        {
            if (playerController.playerInput.HasMoveInput())
            {
                playerStateMachine.ChangeState(playerController.playerRunState);
            }
            else 
            {
                playerStateMachine.ChangeState(playerController.playerIdleState);
            }
        }
    }
}
