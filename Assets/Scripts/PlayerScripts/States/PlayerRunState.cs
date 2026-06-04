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

    public override void LogicUpdate()
    {
        CheckFallState();
    }
    public override void PhysicUpdate()
    {
        PlayerRun();
    }

    public override void HandleInput()
    {
        CheckJumpInput();
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

    #region Check state input
    private void CheckIdleInput() 
    {
        if (!playerController.playerInput.HasMoveInput()) 
        {
            playerStateMachine.ChangeState(playerController.playerIdleState);
        }
    }

    private void CheckJumpInput()
    {
        if (playerController.playerInput.JumpPessed && playerController.playerGroundDetector.IsGround())
        {
            playerStateMachine.ChangeState(playerController.playerJumpState);
        }
    }
    #endregion

    #region Check State logic
    private void CheckFallState() 
    {
        if (!playerController.playerGroundDetector.IsGround()) 
        {
            playerStateMachine.ChangeState(playerController.playerFallState);
        }
    }
    #endregion
}
