using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
   public PlayerIdleState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
   {

   }

    public override void Enter()
    {
        StopMovement();
        PlayIdleAnimation();
    }

    public override void LogicUpdate()
    {
        CheckDeathState();
        CheckFallState();
    }
    public override void HandleInput() 
    {
        CheckAttackInput();
        CheckJumpInput();
        CheckRunInput();
    }

    private void StopMovement() 
    {
        playerController.playerMovement.Stop();
    }

    private void PlayIdleAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Idle);
    }

    #region Check state input
    private void CheckRunInput() 
    {
        if (playerController.playerInput.HasMoveInput()) 
        {
            playerStateMachine.ChangeState(playerController.playerRunState);
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

    private void CheckDeathState() 
    {
        if (!playerController.playerHealth.IsAlive()) 
        {
            playerStateMachine.ChangeState(playerController.PlayerDeathState);
        }
    }
    #endregion
}
