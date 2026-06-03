using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
    public PlayerJumpState(PlayerController playerController, PlayerStateMachine playerStateMachine) : base(playerController, playerStateMachine)
    {

    }

    public override void Enter()
    {
        PlayerJump();
        PlayJumpAnimation();
        ResetJumpInput();
    }

    public override void LogicUpdate()
    {
        ChangeToFallState();
    }
    public override void PhysicUpdate()
    {
        MoveInAir();
    }

    public override void HandleInput()
    {
        
    }

    #region Start Jump
    private void PlayJumpAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Jump);
    }

    private void PlayerJump() 
    {
        playerController.playerMovement.Jump(playerController.PlayerData.jumpForce);
    }

    private void ResetJumpInput() 
    {
        playerController.playerInput.ResetJumpInput();
    }
    #endregion


    private void ChangeToFallState() 
    {
        if (playerController.playerMovement.GetVeticalVelocity() > 0f) 
        {
            playerStateMachine.ChangeState(playerController.playerFallState);
        }
    }
    private void MoveInAir() 
    {
        playerController.playerMovement.Run(playerController.playerInput.MoveInput, playerController.PlayerData.runSpeed);
    }

}
