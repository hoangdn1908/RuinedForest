using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        PlayRunAnimation();
    }

    public override void PhysicUpdate()
    {
        PlayerRun();
    }

    public override void HandleInput()
    {
        CheckIdleInput();
    }

    private void PlayRunAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Run);
    }

    private void PlayerRun() 
    {
        playerController.playerMovement.Run(playerController.playerInput.MoveInput, playerController.PlayerData.runSpeed);
    }

    private void CheckIdleInput() 
    {
        if (!playerController.playerInput.HasMoveInput()) 
        {
            playerStateMachine.ChangeState(playerController.playerIdleState);
        }
    }
}
