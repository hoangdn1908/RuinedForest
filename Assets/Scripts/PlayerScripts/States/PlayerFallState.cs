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
        CheckDeathState();
        ExitFall();
    }

    public override void PhysicUpdate()
    {
        MoveInAir();
    }

    public override void HandleInput()
    {
        CheckAttackInput();
    }
    private void PlayFallAnimation() 
    {
        playerController.playerAnimation.SetStateAnimation(PlayerAnimationStates.Fall);
    }

    private void MoveInAir()
    {
        playerController.playerMovement.Run(playerController.playerInput.MoveInput, playerController.PlayerData.runSpeed);
    }

    private void ExitFall() 
    {
        if (playerController.playerGroundDetector.IsGround()) 
        {
            SpawnLandDust();
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

    private void SpawnLandDust()
    {
        if (playerController.playerEffects != null)
        {
            playerController.playerEffects.SpawnLandDust();
        }
    }

    private void CheckAttackInput()
    {
        if (playerController.playerInput.AttackPressed)
        {
            playerStateMachine.ChangeState(playerController.playerAttackState);
        }
    }
    private void CheckDeathState()
    {
        if (!playerController.playerHealth.IsAlive())
        {
            playerStateMachine.ChangeState(playerController.PlayerDeathState);
        }
    }
}
