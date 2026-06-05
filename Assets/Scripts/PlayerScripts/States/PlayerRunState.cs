using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        PlayRunDust();
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
        CheckAttackInput();
        CheckJumpInput();
        CheckIdleInput();
    }

    public override void Exit()
    {
        StopRunDust();
    }

    private void PlayRunAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Run);
    }

    private void PlayerRun() 
    {
        playerController.playerMovement.Run(playerController.playerInput.MoveInput, playerController.PlayerData.runSpeed);
    }

    #region Run effect
    private void PlayRunDust() 
    {
        if (playerController.playerGroundDetector.IsGround() && Mathf.Abs(playerController.playerInput.MoveInput) > 0.1f) 
        {
            playerController.playerEffects.PlayRunDust();
        }
    }

    private void StopRunDust() 
    {
        if (!playerController.playerGroundDetector.IsGround() || playerController.playerInput.MoveInput <= 0f)
        {
            playerController.playerEffects.StopRunDust();
        }
    }
    #endregion

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

    private void CheckAttackInput()
    {
        if (playerController.playerInput.AttackPressed)
        {
            playerStateMachine.ChangeState(playerController.playerAttackState);
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
